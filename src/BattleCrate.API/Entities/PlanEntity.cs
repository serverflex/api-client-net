using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class PlanEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the amount of backup-allocated-storage (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("backupsInMb")]
        public int BackupStorage { get; set; }

        /// <summary>
        /// Gets or sets whether the Plan can currently be deployed.
        /// </summary>
        [JsonProperty("canUse")]
        public bool CanUse { get; set; }

        /// <summary>
        /// Gets or sets the Plan's hourly cost.
        /// </summary>
        [JsonProperty("costHour")]
        public float CostPerHour { get; set; }

        /// <summary>
        /// Gets or sets the Plan's monthly cost.
        /// </summary>
        [JsonProperty("costMonthly")]
        public float CostPerMonth { get; set; }

        /// <summary>
        /// Gets or sets the number of vCPUs provided by the Plan.
        /// </summary>
        [JsonProperty("cpuCount")]
        public float CpuCount { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Package that the Plan belongs to.
        /// </summary>
        [JsonProperty("packageName")]
        public string CratePackageName { get; set; }

        /// <summary>
        /// Gets or sets the Plan's currency in ISO 4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the Plan's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the amount of memory (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("memoryInMb")]
        public int Memory { get; set; }

        /// <summary>
        /// Gets or sets the Plan's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

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
        [JsonProperty("storageInMb")]
        public int Storage { get; set; }
        #endregion
    }
}
