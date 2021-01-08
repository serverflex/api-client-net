using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePlanResourcesEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the amount of backup-allocated-storage (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("backupsInMB")]
        public int BackupStorage { get; set; }

        /// <summary>
        /// Gets or sets the number of vCPUs provided by the Plan.
        /// </summary>
        [JsonProperty("cpuCount")]
        public double CpuCount { get; set; }

        /// <summary>
        /// Gets or sets the amount of memory (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("memoryInMB")]
        public int Memory { get; set; }

        /// <summary>
        /// Gets or sets the amount of storage (in MB) provided by the Plan.
        /// </summary>
        [JsonProperty("storageInMB")]
        public int Storage { get; set; }
        #endregion
    }
}
