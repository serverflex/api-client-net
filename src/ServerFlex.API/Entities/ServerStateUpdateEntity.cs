using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerStateUpdateEventEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the server state. See <see cref="Schema.ServerState" />.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
        #endregion
    }
}
