using Newtonsoft.Json;
using System;

namespace ServerFlex.API.Entities
{
    public class OperationEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the time that the operation was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the time that the operation was completed, if any.
        /// </summary>
        [JsonProperty("completedAt")]
        public DateTimeOffset? CompletedAt { get; set; }

        /// <summary>
        /// Gets or sets whether the operation is completed.
        /// </summary>
        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets whether the operation completed succesfully.
        /// </summary>
        [JsonProperty("isCompletedSuccesfully")]
        public bool IsCompletedSuccesfully { get; set; }

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the operation UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }
        #endregion
    }
}
