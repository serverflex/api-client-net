using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerFlex.API.Authentication;
using ServerFlex.API.Entities;
using ServerFlex.API.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Base
{
    public abstract class BaseApiClient : IApiRequestor, IEventApiRequestor
    {
        #region Fields
        private bool _hasReauthorized;
        private ClientWebSocket _webSocketClient;
        #endregion

        #region Events
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<EventReceivedEventArgs> EventReceived;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the API authentication.
        /// </summary>
        public IApiAuthentication Authentication { get; set; }

        /// <summary>
        /// Gets or sets the base URI to use for the API.
        /// </summary>
        public Uri BaseApiUri { get; set; }

        /// <summary>
        /// Gets or sets the base URI to use for the event API.
        /// </summary>
        public Uri BaseEventApiUri { get; set; }

        /// <summary>
        /// Gets the API client's underlying HTTP client.
        /// </summary>
        public HttpClient HttpClient { get; }

        /// <summary>
        /// Gets or sets how many times an operation should be retried for transient failures. Default value: 3.
        /// </summary>
        public int RetryCount { get; set; } = 3;

        /// <summary>
        /// Gets or sets how long to wait between retrying operations. Default value: 3 seconds.
        /// </summary>
        public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(3);

        /// <summary>
        /// Gets the API client's underlying WebSocket client.
        /// </summary>
        public ClientWebSocket WebSocketClient
        {
            get
            {
                if (_webSocketClient == null)
                    _webSocketClient = new ClientWebSocket();

                else if (_webSocketClient.State != WebSocketState.Open)
                {
                    _webSocketClient.Dispose();

                    _webSocketClient = new ClientWebSocket();
                }

                return _webSocketClient;
            }
        }
        #endregion

        #region REST Methods
        /// <summary>
        /// Sends a raw REST request to the API. Includes error handling logic but no retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        async Task<HttpResponseMessage> IApiRequestor.RawRequestAsync(HttpMethod method, string path, HttpContent content, bool formatBaseApiUri, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (Authentication == null)
                throw new NullReferenceException("No authentication provided.");

            var request = new HttpRequestMessage(method, formatBaseApiUri ? BaseApiUri + path : path);

            Authentication.ApplyToRequest(request);

            if (method != HttpMethod.Get)
                request.Content = content;

            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return response;

            cancellationToken.ThrowIfCancellationRequested();

            ApiError error;

            try
            {
                error = JsonConvert.DeserializeObject<ApiError>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            catch (Exception)
            {
                throw ApiException.InvalidServerResponse(response);
            }

            throw new ApiException("An API exception occurred.", response, error);
        }

        /// <summary>
        /// Sends a REST request to the API. Includes retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri" />.</param>
        Task<HttpResponseMessage> IApiRequestor.RequestAsync<TRequest>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            return ((IApiRequestor)this).RequestAsync(method, path, SerializeContent(content), cancellationToken, formatBaseApiUri);
        }

        /// <summary>
        /// Sends a REST request to the API. Includes retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri" />.</param>
        async Task<HttpResponseMessage> IApiRequestor.RequestAsync(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            _hasReauthorized = false;

            for (var i = 0; i < RetryCount; i++)
            {
                try
                {
                    var response = await ((IApiRequestor)this).RawRequestAsync(method, path, content, formatBaseApiUri, cancellationToken).ConfigureAwait(false);

                    return response;
                }
                catch (ApiException e)
                    when (e.ResponseMessage.StatusCode == HttpStatusCode.Unauthorized && !_hasReauthorized)
                {
                    var retry = await Authentication.ReauthorizeAsync(this).ConfigureAwait(false);

                    if (retry)
                    {
                        i--;

                        _hasReauthorized = true;

                        continue;
                    }
                    else
                        throw;
                }
                catch (ApiException e)
                    when (e.ResponseMessage.StatusCode == HttpStatusCode.BadGateway && i < RetryCount - 1)
                {
                    await Task.Delay(RetryDelay).ConfigureAwait(false);

                    continue;
                }
            }

            throw new NotImplementedException("Unreachable.");
        }

        /// <summary>
        /// Get all available items from all pages.
        /// </summary>
        /// <param name="path">The request path without query parameters.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        async Task<TEntity[]> IApiRequestor.RequestEntireListJsonSerializedAsync<TEntity>(string path, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            var page = 1;
            var totalPages = 1;

            var entities = new List<TEntity>();

            while (page <= totalPages)
            {
                var pageOfEntities = await ((IApiRequestor)this).RequestResultResponseJsonSerializedAsync<TEntity>(50, page, path, cancellationToken, formatBaseApiUri).ConfigureAwait(false);

                entities.AddRange(pageOfEntities.Results);

                page++;
                totalPages = pageOfEntities.TotalPages;
            }

            return entities.ToArray();
        }

        /// <summary>
        /// Request a serialized object response.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri" />.</param>
        Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod method, string path, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            return ((IApiRequestor)this).RequestJsonSerializedAsync<TResponse>(method, path, null, cancellationToken, formatBaseApiUri);
        }

        /// <summary>
        /// Request a serialized object response with serialized content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri" />.</param>
        Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TRequest, TResponse>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            return ((IApiRequestor)this).RequestJsonSerializedAsync<TResponse>(method, path, SerializeContent(content), cancellationToken, formatBaseApiUri);
        }

        /// <summary>
        /// Request a serialized object response with content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri" />.</param>
        async Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            var response = await ((IApiRequestor)this).RequestAsync(method, path, content, cancellationToken, formatBaseApiUri).ConfigureAwait(false);

            if (!response.Content.Headers.ContentType.MediaType.StartsWith("application/json", StringComparison.CurrentCultureIgnoreCase))
                throw ApiException.InvalidServerResponse(response);

            return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Get a page of items.
        /// </summary>
        /// <param name="limit">The maximum number of items that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        /// <param name="path">The request path without request parameters.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri" />.</param>
        Task<ResultResponseEntity<TEntity>> IApiRequestor.RequestResultResponseJsonSerializedAsync<TEntity>(int limit, int page, string path, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            if (limit < 1 || limit > 50)
                throw new ArgumentOutOfRangeException(nameof(limit), "The limit must be between 1 and 50.");

            return ((IApiRequestor)this).RequestJsonSerializedAsync<ResultResponseEntity<TEntity>>(HttpMethod.Get, $"{path}?limit={limit}&page={page}", cancellationToken, formatBaseApiUri);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Connect to the event API via WebSockets.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        public async Task ConnectAsync(string token, CancellationToken cancellationToken = default)
        {
            if (WebSocketClient.State != WebSocketState.Open)
            {
                await WebSocketClient.ConnectAsync(new Uri($"{BaseEventApiUri}?token={token}"), cancellationToken).ConfigureAwait(false);

                OnConnected(new EventArgs());

                _ = Task.Run(ReadLoopAsync);
            }
        }
        #endregion

        #region Protected Methods
        protected virtual void OnConnected(EventArgs e)
        {
            Connected?.Invoke(this, e);
        }

        protected virtual void OnDisconnected(EventArgs e)
        {
            Disconnected?.Invoke(this, e);
        }

        protected virtual void OnEventReceived(EventReceivedEventArgs e)
        {
            EventReceived?.Invoke(this, e);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new ServerFlex API client with an optional custom base URI.
        /// </summary>
        /// <param name="baseApiUri">The base URI to use for the API, or null for default.</param>
        /// <param name="baseEventApiUri">The base URI to use for the event API, or null for default.</param>
        protected BaseApiClient(Uri baseApiUri = null, Uri baseEventApiUri = null)
        {
            BaseApiUri = baseApiUri ?? DefaultBaseApiUri;
            BaseEventApiUri = baseEventApiUri ?? DefaultBaseEventApiUri;

            HttpClient = new HttpClient();
        }
        #endregion

        #region Private Methods
        private async Task ReadLoopAsync()
        {
            var buffer = new byte[8192];

            while (WebSocketClient.State == WebSocketState.Open)
            {
                try
                {
                    WebSocketReceiveResult message;

                    do
                    {
                        message = await WebSocketClient.ReceiveAsync(buffer, default).ConfigureAwait(false);
                    }
                    while (!message.EndOfMessage);

                    // If the message type is to close the WebSocket, break the loop to dispose the connection.
                    if (message.MessageType == WebSocketMessageType.Close)
                        break;

                    // If the message type is text, try to parse as an event.
                    else if (message.MessageType == WebSocketMessageType.Text)
                    {
                        using var memoryStream = new MemoryStream(buffer);
                        using var streamReader = new StreamReader(memoryStream, Encoding.UTF8);

                        try
                        {
                            var eventEntity = JsonConvert.DeserializeObject<EventEntity>(streamReader.ReadToEnd());

                            OnEventReceived(new EventReceivedEventArgs(eventEntity));
                        }
                        catch
                        {
                            // Ignore.
                        }
                    }
                }
                catch
                {
                    break;
                }
            }

            // If we're here, the WebSocket has disconnected.

            WebSocketClient.Dispose();

            OnDisconnected(new EventArgs());
        }

        private HttpContent SerializeContent<TContent>(TContent content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }
        #endregion

        #region Constant Values
        public static readonly Uri DefaultBaseApiUri = new("https://api.serverflex.io/1.0/");
        public static readonly Uri DefaultBaseEventApiUri = new("wss://api.serverflex.io/1.0/websockets");
        #endregion
    }
}
