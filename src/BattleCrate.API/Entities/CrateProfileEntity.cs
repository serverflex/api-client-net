using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateProfileEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the Profile can have services deployed to it.
        /// </summary>
        [JsonProperty("canDeploy")]
        public bool CanDeploy { get; set; }

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

        /// <summary>
        /// Gets or sets the name of the Crate Package that the Profile belongs to.
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }
        #endregion
    }
}
