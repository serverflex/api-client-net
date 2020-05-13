using System;
using System.Net.Http;
using System.Net.Http.Headers;

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
        #endregion

        #region Constant Values
        public static readonly Uri DefaultBaseApiUri = new Uri("https://api.battlecrate.co.uk/1.0/");
        #endregion
    }
}
