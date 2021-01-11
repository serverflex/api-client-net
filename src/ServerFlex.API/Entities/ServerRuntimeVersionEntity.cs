using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerRuntimeVersionEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the server Runtime version as a human-readable, displayable string.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server Runtime version.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
