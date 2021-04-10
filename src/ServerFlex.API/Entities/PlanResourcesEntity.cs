using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class PlanResourcesEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the amount of backup-allocated-storage (in megabytes) provided by the plan.
        /// </summary>
        [JsonProperty("backupsMB")]
        public int BackupStorageMB { get; set; }

        /// <summary>
        /// Gets or sets the number of vCPUs provided by the plan.
        /// </summary>
        [JsonProperty("cpuCount")]
        public double CPUCount { get; set; }

        /// <summary>
        /// Gets or sets the amount of memory (in megabytes) provided by the plan.
        /// </summary>
        [JsonProperty("memoryMB")]
        public int MemoryMB { get; set; }

        /// <summary>
        /// Gets or sets the amount of storage (in megabytes) provided by the plan.
        /// </summary>
        [JsonProperty("storageMB")]
        public int StorageMB { get; set; }
        #endregion
    }
}
