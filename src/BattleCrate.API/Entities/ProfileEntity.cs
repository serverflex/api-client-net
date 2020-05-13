using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class ProfileEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Profile's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the Profile's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
