using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePlanEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the amount of backup-allocated-storage (in MB) provided by this Crate Plan.
        /// </summary>
        [JsonProperty("backupsInMB")]
        public int BackupStorage { get; set; }

        /// <summary>
        /// Gets or sets whether resources can be deployed using this Crate Plan.
        /// </summary>
        [JsonProperty("canUse")]
        public bool CanUse { get; set; }

        /// <summary>
        /// Gets or sets the number of vCPUs provided by this Crate Plan.
        /// </summary>
        [JsonProperty("cpuCount")]
        public double CpuCount { get; set; }

        /// <summary>
        /// Gets or sets the Crate Plan's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the amount of memory (in MB) provided by this Crate Plan.
        /// </summary>
        [JsonProperty("memoryInMB")]
        public int Memory { get; set; }

        /// <summary>
        /// Gets or sets the Crate Plan's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Package that this Crate Plan belongs to.
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the pricing for this Crate Plan. The array contains all available currencies. Depending on where the Crate Plan was requested, pricing may not be included.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingEntity[] Pricing { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Profile that this Crate Plan can be deployed to, if specific. Otherwise, null.
        /// </summary>
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Region that this Crate Plan can be deployed to, if specific. Otherwise, null.
        /// </summary>
        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets the amount of storage (in MB) provided by this Crate Plan.
        /// </summary>
        [JsonProperty("storageInMB")]
        public int Storage { get; set; }
        #endregion
    }
}
