using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServerFlex.API.Entities
{
    public class ServerRuntimeVersionEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the version display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the version metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Gets or sets the version name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
