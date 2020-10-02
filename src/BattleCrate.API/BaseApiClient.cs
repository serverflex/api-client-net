using BattleCrate.API.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API
{
    public abstract class BaseApiClient : IBaseApiClient, IApiRequestor
    {
        #region Fields
        private readonly string _apiKey;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the base URI to use for the API.
        /// </summary>
        public Uri BaseApiUri { get; set; }

        /// <summary>
        /// Gets the API client's underlying HTTP client.
        /// </summary>
        public HttpClient HttpClient { get; private set; }

        /// <summary>
        /// Gets or sets how many times an operation should be retried for transient failures. Default value: 3.
        /// </summary>
        public int RetryCount { get; set; } = 3;

        /// <summary>
        /// Gets or sets how long to wait between retrying operations. Default value: 3 seconds.
        /// </summary>
        public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(3);
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

            var request = new HttpRequestMessage(method, formatBaseApiUri ? BaseApiUri + path : path);

            if (method != HttpMethod.Get)
                request.Content = content;

            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return response;

            cancellationToken.ThrowIfCancellationRequested();

            string error;
            ApiError[] errors;

            try
            {
                var obj = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

                errors = JsonConvert.DeserializeObject<ApiError[]>(obj["errors"].ToString());

                if (errors.Length > 1)
                    error = $"{errors.Length} errors occurred.";
                else
                    error = string.IsNullOrWhiteSpace(errors[0].Message) ? "Unspecified error" : errors[0].Message;
            }
            catch (Exception)
            {
                throw ApiException.InvalidServerResponse(response);
            }

            throw new ApiException(error, response, errors);
        }

        /// <summary>
        /// Sends a REST request to the API. Includes retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        Task<HttpResponseMessage> IApiRequestor.RequestAsync<TRequest>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken, bool formatBaseApiUri)
            => ((IApiRequestor)this).RequestAsync(method, path, SerializeContent(content), cancellationToken, formatBaseApiUri);

        /// <summary>
        /// Sends a REST request to the API. Includes retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        async Task<HttpResponseMessage> IApiRequestor.RequestAsync(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            for (var i = 0; i < RetryCount; i++)
            {
                try
                {
                    return await ((IApiRequestor)this).RawRequestAsync(method, path, content, formatBaseApiUri, cancellationToken).ConfigureAwait(false);
                }
                catch (ApiException e)
                {
                    if (e.StatusCode == HttpStatusCode.BadGateway && i < RetryCount - 1)
                    {
                        await Task.Delay(RetryDelay).ConfigureAwait(false);

                        continue;
                    }

                    throw;
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
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod method, string path, CancellationToken cancellationToken, bool formatBaseApiUri)
            => ((IApiRequestor)this).RequestJsonSerializedAsync<TResponse>(method, path, null, cancellationToken, formatBaseApiUri);

        /// <summary>
        /// Request a serialized object response with serialized content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TRequest, TResponse>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken, bool formatBaseApiUri)
            => ((IApiRequestor)this).RequestJsonSerializedAsync<TResponse>(method, path, SerializeContent(content), cancellationToken, formatBaseApiUri);

        /// <summary>
        /// Request a serialized object response with content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
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
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        Task<ResultResponseEntity<TEntity>> IApiRequestor.RequestResultResponseJsonSerializedAsync<TEntity>(int limit, int page, string path, CancellationToken cancellationToken, bool formatBaseApiUri)
        {
            if (limit < 1 || limit > 50)
                throw new ArgumentOutOfRangeException(nameof(limit), "The limit must be between 1 and 50.");

            return ((IApiRequestor)this).RequestJsonSerializedAsync<ResultResponseEntity<TEntity>>(HttpMethod.Get, $"{path}?limit={limit}&page={page}", cancellationToken, formatBaseApiUri);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new BattleCrate API client with an API key and an optional custom base URI.
        /// </summary>
        /// <param name="apiKey">Your BattleCrate API key.</param>
        /// <param name="baseApiUri">The base URI to use for the API, or null for default.</param>
        protected BaseApiClient(string apiKey, Uri baseApiUri = null)
        {
            BaseApiUri = baseApiUri ?? DefaultBaseApiUri;

            HttpClient = new HttpClient();

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("API key must not be null or empty.");
            else
            {
                _apiKey = apiKey;

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            }
        }
        #endregion

        #region Private Methods
        private HttpContent SerializeContent<TContent>(TContent content)
            => new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        #endregion

        #region Constant Values
        public static readonly Uri DefaultBaseApiUri = new Uri("https://api.battlecrate.io/1.0/");
        #endregion
    }
}
