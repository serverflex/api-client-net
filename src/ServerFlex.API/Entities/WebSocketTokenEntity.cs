using Newtonsoft.Json;
using System;

namespace ServerFlex.API.Entities
{
    public class WebSocketTokenEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the expiry time, in UTC format.
        /// </summary>
        [JsonProperty("expiryTime")]
        public DateTimeOffset ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the WebSocket token.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
        #endregion
    }
}
