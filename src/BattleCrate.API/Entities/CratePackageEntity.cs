using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePackageEntity
    {
        #region Properties
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
        /// Gets or sets the Regions that this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("regions")]
        public RegionEntity[] Regions { get; set; }

        /// <summary>
        /// Gets or sets the Crate Runtimes available for this Crate Package.
        /// </summary>
        [JsonProperty("runtimes")]
        public CrateRuntimeEntity[] Runtimes { get; set; }

        /// <summary>
        /// Gets or sets the total number of Crate Plans available for this Crate Package.
        /// </summary>
        [JsonProperty("totalPlanCount")]
        public int TotalPlanCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of Regions this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("totalRegionCount")]
        public int TotalRegionCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of Crate Runtimes available for this Crate Package.
        /// </summary>
        [JsonProperty("totalRuntimes")]
        public int TotalRuntimeCount { get; set; }
        #endregion
    }
}
