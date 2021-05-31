using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class SubscriptionNewEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        [JsonProperty("resourceId")]
        public string ResourceID { get; set; }

        /// <summary>
        /// Gets or sets the resource type.
        /// </summary>
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }
        #endregion
    }
}
