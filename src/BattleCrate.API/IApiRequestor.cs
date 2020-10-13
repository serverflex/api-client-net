using BattleCrate.API.Entities;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API
{
    public interface IApiRequestor
    {
        #region Properties
        /// <summary>
        /// Gets or sets the base URI to use for the API.
        /// </summary>
        Uri BaseApiUri { get; set; }

        /// <summary>
        /// Gets the API client's underlying HTTP client.
        /// </summary>
        HttpClient HttpClient { get; }

        /// <summary>
        /// Gets or sets how many times an operation should be retried for transient failures.
        /// </summary>
        int RetryCount { get; set; }

        /// <summary>
        /// Gets or sets how long to wait between retrying operations.
        /// </summary>
        TimeSpan RetryDelay { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Sends a raw REST request to the API. Includes error handling logic but no retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        Task<HttpResponseMessage> RawRequestAsync(HttpMethod method, string path, HttpContent content, bool formatBaseApiUri, CancellationToken cancellationToken);

        /// <summary>
        /// Sends a REST request to the API. Includes retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        Task<HttpResponseMessage> RequestAsync<TRequest>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken, bool formatBaseApiUri = true);

        /// <summary>
        /// Sends a REST request to the API. Includes retry logic.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content, if any.</param>
        /// <param name="formatBaseApiUri">Whether to format the provided path with the client's <see cref="BaseApiUri "/>.</param>
        Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken, bool formatBaseApiUri = true);

        /// <summary>
        /// Get all available items from all pages.
        /// </summary>
        /// <param name="path">The request path without query parameters.</param>
        Task<TEntity[]> RequestEntireListJsonSerializedAsync<TEntity>(string path, CancellationToken cancellationToken, bool formatBaseApiUri = true);

        /// <summary>
        /// Request a serialized object response.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        Task<TResponse> RequestJsonSerializedAsync<TResponse>(HttpMethod method, string path, CancellationToken cancellationToken, bool formatBaseApiUri = true);

        /// <summary>
        /// Request a serialized object response with serialized content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        Task<TResponse> RequestJsonSerializedAsync<TRequest, TResponse>(HttpMethod method, string path, TRequest content, CancellationToken cancellationToken, bool formatBaseApiUri = true);

        /// <summary>
        /// Request a serialized object response with content.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="content">The request content.</param>
        Task<TResponse> RequestJsonSerializedAsync<TResponse>(HttpMethod method, string path, HttpContent content, CancellationToken cancellationToken, bool formatBaseApiUri = true);

        /// <summary>
        /// Get a page of items.
        /// </summary>
        /// <param name="limit">The maximum number of items that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        /// <param name="path">The request path without request parameters.</param>
        Task<ResultResponseEntity<TEntity>> RequestResultResponseJsonSerializedAsync<TEntity>(int limit, int page, string path, CancellationToken cancellationToken, bool formatBaseApiUri = true);
        #endregion
    }
}
