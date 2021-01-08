using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateRuntimeVersionEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the Crate Runtime version as a human-readable, displayable string.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Runtime version.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
