using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePlanEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the amount of backup-allocated-storage (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("backupsInMB")]
        public int BackupStorage { get; set; }

        /// <summary>
        /// Gets or sets whether the Plan can currently be deployed.
        /// </summary>
        [JsonProperty("canUse")]
        public bool CanUse { get; set; }

        /// <summary>
        /// Gets or sets the number of vCPUs provided by the Plan.
        /// </summary>
        [JsonProperty("cpuCount")]
        public double CpuCount { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Package that the Plan belongs to.
        /// </summary>
        [JsonProperty("packageName")]
        public string CratePackageName { get; set; }

        /// <summary>
        /// Gets or sets the Plan's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the amount of memory (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("memoryInMB")]
        public int Memory { get; set; }

        /// <summary>
        /// Gets or sets the Plan's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pricing for the Plan. The array contains all available currencies. Depending on where the Plan was requested, pricing may not be included.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingEntity[] Pricing { get; set; }

        /// <summary>
        /// Gets or sets the name of the Profile that this Plan can be deployed to, if specific. Otherwise, null.
        /// </summary>
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Region that this Plan can be deployed to, if specific. Otherwise, null.
        /// </summary>
        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets the amount of storage (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("storageInMB")]
        public int Storage { get; set; }
        #endregion
    }
}
