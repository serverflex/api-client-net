using BattleCrate.API.Authentication.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BattleCrate.API.Authentication
{
    public class ApiKeyAuthentication : BaseApiAuthentication
    {
        #region Fields
        private string _apiKey;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey
        {
            get => _apiKey;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("API key must not be null or empty.");

                _apiKey = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Applies the authentication to an outgoing request.
        /// </summary>
        /// <param name="request">The outgoing request.</param>
        public override void ApplyToRequest(HttpRequestMessage request)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
        }

        /// <summary>
        /// Attempts to reauthorize.
        /// </summary>
        /// <param name="apiRequestor">The API requestor.</param>
        public override Task<bool> ReauthorizeAsync(IApiRequestor apiRequestor)
        {
            return Task.FromResult(false);
        }
        #endregion

        #region Protected Methods
        protected override void DeserializeFromStream(Stream stream)
        {
            using var streamReader = new StreamReader(stream);

            var authorization = JsonConvert.DeserializeObject<Dictionary<string, string>>(streamReader.ReadToEnd());

            ApiKey = authorization["apiKey"];
        }

        protected override void SerializeToStream(Stream stream)
        {
            using var streamWriter = new StreamWriter(stream, Encoding.UTF8, 4096, true);

            streamWriter.WriteLine(JsonConvert.SerializeObject(new Dictionary<string, string>()
            {
                ["apiKey"] = ApiKey
            }));
        }
        #endregion
    }
}
