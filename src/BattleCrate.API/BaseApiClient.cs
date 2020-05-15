﻿using BattleCrate.API.Entities;
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
        private string _apiKey;
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
        Uri IBaseApiClient.BaseApiUri { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        HttpClient IBaseApiClient.HttpClient => throw new NotImplementedException();

        int IBaseApiClient.RetryCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        TimeSpan IBaseApiClient.RetryDelay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region REST Methods
        /// <summary>
        /// Sends a raw REST request to the API. Includes error handling logic but no reauthorisation or retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        async Task<HttpResponseMessage> IApiRequestor.RawRequestAsync(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var request = new HttpRequestMessage(method, path);

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
                    error = $"{errors.Length} {(errors.Length == 1 ? "error" : "errors")} occurred.";
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
        /// Sends a REST request to the API. Includes retry logic and reauthorization.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        Task<HttpResponseMessage> IApiRequestor.RequestAsync<TRequest>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken)
            => ((IApiRequestor)this).RequestAsync(method, path, SerializeContent(content), cancellationToken);

        /// <summary>
        /// Sends a REST request to the API. Includes retry logic and reauthorization.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        async Task<HttpResponseMessage> IApiRequestor.RequestAsync(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken)
        {
            for (var i = 0; i < RetryCount; i++)
            {
                try
                {
                    return await ((IApiRequestor)this).RawRequestAsync(method, path, content, cancellationToken).ConfigureAwait(false);
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
        async Task<TEntity[]> IApiRequestor.RequestEntireListJsonSerializedAsync<TEntity>(string path, CancellationToken cancellationToken)
        {
            var page = 1;
            var totalPages = 1;

            var entities = new List<TEntity>();

            while (page <= totalPages)
            {
                var pageOfEntities = await ((IApiRequestor)this).RequestResultResponseJsonSerializedAsync<TEntity>(50, page, path, cancellationToken).ConfigureAwait(false);

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
        Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod method, string path, CancellationToken cancellationToken)
            => ((IApiRequestor)this).RequestJsonSerializedAsync<TResponse>(method, path, null, cancellationToken);

        /// <summary>
        /// Request a serialized object response with serialized content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TRequest, TResponse>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken)
            => ((IApiRequestor)this).RequestJsonSerializedAsync<TResponse>(method, path, SerializeContent(content), cancellationToken);

        /// <summary>
        /// Request a serialized object response with content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        async Task<TResponse> IApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await ((IApiRequestor)this).RequestAsync(method, path, content, cancellationToken).ConfigureAwait(false);

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
        Task<ResultResponseEntity<TEntity>> IApiRequestor.RequestResultResponseJsonSerializedAsync<TEntity>(int limit, int page, string path, CancellationToken cancellationToken)
        {
            if (limit < 1 || limit > 50)
                throw new ArgumentOutOfRangeException(nameof(limit), "The limit must be between 1 and 50.");

            return ((IApiRequestor)this).RequestJsonSerializedAsync<ResultResponseEntity<TEntity>>(HttpMethod.Get, $"{path}?limit={limit}&page={page}", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new BattleCrate API client.
        /// </summary>
        protected BaseApiClient()
            => Initialize(null, null, false);

        /// <summary>
        /// Creates a new BattleCrate API client with an API key.
        /// </summary>
        /// <param name="apiKey">Your BattleCrate API key.</param>
        protected BaseApiClient(string apiKey)
            => Initialize(null, apiKey, true);

        /// <summary>
        /// Creates a new BattleCrate API client with a custom base URI.
        /// </summary>
        /// <param name="baseApiUri">The base URI to use for the API.</param>
        protected BaseApiClient(Uri baseApiUri)
            => Initialize(baseApiUri, null, false);

        /// <summary>
        /// Creates a new BattleCrate API client with a custom base URI and an API key.
        /// </summary>
        /// <param name="baseApiUri">The base URI to use for the API.</param>
        /// <param name="apiKey">Your BattleCrate API key.</param>
        protected BaseApiClient(Uri baseApiUri, string apiKey)
            => Initialize(baseApiUri, apiKey, true);
        #endregion

        #region Private Methods
        private void Initialize(Uri baseApiUri, string apiKey, bool checkForEmptyApiKey)
        {
            BaseApiUri = baseApiUri ?? DefaultBaseApiUri;

            HttpClient = new HttpClient
            {
                BaseAddress = BaseApiUri
            };

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                if (checkForEmptyApiKey)
                    throw new ArgumentException("API key must not be null or empty.");
            }
            else
            {
                _apiKey = apiKey;

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            }
        }

        private HttpContent SerializeContent<TContent>(TContent content)
            => new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        #endregion

        #region Constant Values
        public static readonly Uri DefaultBaseApiUri = new Uri("https://api.battlecrate.co.uk/1.0/");
        #endregion
    }
}
