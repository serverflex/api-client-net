using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServerFlex.API.Entities
{
    public class ServerRuntimeEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the version aliases available for this server Runtime.
        /// </summary>
        [JsonProperty("aliases")]
        public Dictionary<string, string> Aliases { get; set; }

        /// <summary>
        /// Gets or sets the name of the server Runtime as a human-readable, displayable string.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server Runtime.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the versions available for this server Runtime.
        /// </summary>
        [JsonProperty("versions")]
        public ServerRuntimeVersionEntity[] Versions { get; set; }
        #endregion
    }
}
