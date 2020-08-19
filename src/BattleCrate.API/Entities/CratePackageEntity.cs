using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleCrate.API.Entities
{
    public class CratePackageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the URLs for this Crate Package's background, in size order.
        /// </summary>
        [JsonProperty("backgroundUrl")]
        public Dictionary<int, string> BackgroundUrl { get; set; }

        /// <summary>
        /// Gets or sets whether resources can be deployed using this Crate Package.
        /// </summary>
        [JsonProperty("canDeploy")]
        public bool CanDeploy { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets URls for this Crate Package's icon, in size order.
        /// </summary>
        [JsonProperty("iconUrl")]
        public Dictionary<int, string> IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Crate Plans available with this Crate Package.
        /// </summary>
        [JsonProperty("plans")]
        public CratePlanEntity[] Plans { get; set; }

        /// <summary>
        /// Gets or sets the Crate Profiles available with this Crate Package.
        /// </summary>
        [JsonProperty("profiles")]
        public CrateProfileEntity[] Profiles { get; set; }

        /// <summary>
        /// Gets or sets the Regions that this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("regions")]
        public RegionEntity[] Regions { get; set; }

        /// <summary>
        /// Gets or sets the total number of Crate Plans available for this Crate Package.
        /// </summary>
        [JsonProperty("totalPlanCount")]
        public int TotalPlanCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of Crate Profiles available for this Crate Package.
        /// </summary>
        [JsonProperty("totalProfileCount")]
        public int TotalProfileCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of Regions this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("totalRegionCount")]
        public int TotalRegionCount { get; set; }
        #endregion
    }
}
