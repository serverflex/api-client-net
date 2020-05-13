using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class RegionEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Region's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the Region's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
