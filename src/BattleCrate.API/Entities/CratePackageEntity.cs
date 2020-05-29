using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePackageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the URL of the background associated with the Crate Package.
        /// </summary>
        [JsonProperty("backgroundUrl")]
        public string BackgroundUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the Crate Package can have services deployed to it.
        /// </summary>
        [JsonProperty("canDeploy")]
        public bool CanDeploy { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the icon associated with the Crate Package.
        /// </summary>
        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's Plans.
        /// </summary>
        [JsonProperty("plans")]
        public CratePlanEntity[] Plans { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's Profiles.
        /// </summary>
        [JsonProperty("profiles")]
        public CrateProfileEntity[] Profiles { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's Regions.
        /// </summary>
        [JsonProperty("regions")]
        public RegionEntity[] Regions { get; set; }

        /// <summary>
        /// Gets or sets the total number of Plans available for the Crate Package.
        /// </summary>
        [JsonProperty("totalPlanCount")]
        public int TotalPlanCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of Profiles available for the Crate Package.
        /// </summary>
        [JsonProperty("totalProfileCount")]
        public int TotalProfileCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of Regions available for the Crate Package.
        /// </summary>
        [JsonProperty("totalRegionCount")]
        public int TotalRegionCount { get; set; }
        #endregion
    }
}
