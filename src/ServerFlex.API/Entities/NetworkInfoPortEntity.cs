using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class NetworkInfoPortEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the port name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the port protocol.
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; }
        #endregion
    }
}
