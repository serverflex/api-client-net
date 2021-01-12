using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class NetworkInfoEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the IP Address.
        /// </summary>
        [JsonProperty("ipAddress")]
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets all open ports.
        /// </summary>
        [JsonProperty("ports")]
        public NetworkInfoPortEntity[] Ports { get; set; }

        /// <summary>
        /// Gets or sets the subdomain.
        /// </summary>
        [JsonProperty("subDomain")]
        public string SubDomain { get; set; }
        #endregion        
    }
}
