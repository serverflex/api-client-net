using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleCrate.API.Entities
{
    public class CrateRuntimeEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the version aliases available for this Crate Runtime.
        /// </summary>
        [JsonProperty("aliases")]
        public Dictionary<string, string> Aliases { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Runtime as a human-readable, displayable string.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Runtime.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the versions available for this Crate Runtime.
        /// </summary>
        [JsonProperty("versions")]
        public CrateRuntimeVersionEntity[] Versions { get; set; }
        #endregion
    }
}
