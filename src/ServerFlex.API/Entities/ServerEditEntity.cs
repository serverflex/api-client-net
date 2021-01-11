using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerEditEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the new name for the server.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
