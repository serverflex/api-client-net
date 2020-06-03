using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCrate.API.Entities
{
    public class OperationEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets if this operation is completed.
        /// </summary>
        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets if this operation completed succesfully.
        /// </summary>
        [JsonProperty("isCompletedSuccesfully")]
        public bool IsCompletedSuccesfully { get; set; }

        /// <summary>
        /// Gets or sets the created at time.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the completed at time.
        /// </summary>
        [JsonProperty("completedAt")]
        public DateTimeOffset? CompletedAt { get; set; }
        #endregion
    }
}
