using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateProfileEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether resources can be deployed using this Crate Profile.
        /// </summary>
        [JsonProperty("canDeploy")]
        public bool CanDeploy { get; set; }

        /// <summary>
        /// Gets or sets the Crate Profile's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the Crate Profile's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Package that this Crate Profile belongs to.
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }
        #endregion
    }
}
