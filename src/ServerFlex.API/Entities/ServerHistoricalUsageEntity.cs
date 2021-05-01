using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ServerFlex.API.Entities
{
    public class ServerHistoricalUsageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the historical CPU usage.
        /// </summary>
        [JsonProperty("cpuUsage")]
        public Dictionary<DateTime, double> CPUUsage { get; set; }

        /// <summary>
        /// Gets or sets the historical RAM usage.
        /// </summary>
        [JsonProperty("ramUsage")]
        public Dictionary<DateTime, double> RAMUsage { get; set; }

        /// <summary>
        /// Gets or sets the historical storage usage.
        /// </summary>
        [JsonProperty("storageUsage")]
        public Dictionary<DateTime, double> StorageUsage { get; set; }
        #endregion
    }
}
