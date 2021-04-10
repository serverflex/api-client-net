using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServerFlex.API.Entities
{
    public class ServerRuntimeEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the available runtime aliases.
        /// </summary>
        [JsonProperty("aliases")]
        public Dictionary<string, string> Aliases { get; set; }

        /// <summary>
        /// Gets or sets the runtime display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the runtime.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the available versions for the runtime.
        /// </summary>
        [JsonProperty("versions")]
        public ServerRuntimeVersionEntity[] Versions { get; set; }
        #endregion
    }
}
