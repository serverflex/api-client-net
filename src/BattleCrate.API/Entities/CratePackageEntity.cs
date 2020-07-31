using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleCrate.API.Entities
{
    public class CratePackageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the URLs for this Crate Package's background.
        /// </summary>
        [JsonProperty("backgroundUrl")]
        public Dictionary<int, string> BackgroundUrl { get; set; }

        /// <summary>
        /// Gets or sets if this Crate Package can be deployed.
        /// </summary>
        [JsonProperty("canDeploy")]
        public bool CanDeploy { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets URls for this Crate Package's icon.
        /// </summary>
        [JsonProperty("iconUrl")]
        public Dictionary<int, string> IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the plans.
        /// </summary>
        [JsonProperty("plans")]
        public CratePlanEntity[] Plans { get; set; }

        /// <summary>
        /// Gets or sets the Crate Profiles.
        /// </summary>
        [JsonProperty("profiles")]
        public CrateProfileEntity[] Profiles { get; set; }

        /// <summary>
        /// Gets or sets a list of Regions this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("regions")]
        public RegionEntity[] Regions { get; set; }

        /// <summary>
        /// Gets or sets the number of Crate Plans available for this Crate Package.
        /// </summary>
        [JsonProperty("totalPlanCount")]
        public int TotalPlanCount { get; set; }

        /// <summary>
        /// Gets or sets the number of Crate Profiles available for this Crate Package.
        /// </summary>
        [JsonProperty("totalProfileCount")]
        public int TotalProfileCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of Regions this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("totalRegionCount")]
        public int? TotalRegionCount { get; set; }
        #endregion
    }
}
