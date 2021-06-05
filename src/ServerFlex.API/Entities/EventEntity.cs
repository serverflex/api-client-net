using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Schema_EventType = ServerFlex.API.Schema.EventType;

namespace ServerFlex.API.Entities
{
    public class EventEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the event type. See <see cref="Schema_EventType" />.
        /// </summary>
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the event payload.
        /// </summary>
        [JsonProperty("payload")]
        public JObject Payload { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        [JsonProperty("resourceId")]
        public string ResourceID { get; set; }

        /// <summary>
        /// Gets or sets the resource type. See <see cref="Schema.ResourceType" />.
        /// </summary>
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Tries to parse the payload to an object.
        /// </summary>
        /// <param name="payload">The parsed payload, or null.</param>
        public bool TryParsePayload(out object payload)
        {
            try
            {
                payload = EventType switch
                {
                    Schema_EventType.ServerStateUpdate => Payload.ToObject<ServerStateUpdateEventEntity>(),
                    _ => throw new Exception()
                };
            }
            catch
            {
                payload = null;
            }

            return payload != null;
        }

        /// <summary>
        /// Tries to parse the payload to an object type.
        /// </summary>
        /// <param name="payload">The parsed payload, or null.</param>
        public bool TryParsePayload<T>(out T payload)
            where T : class
        {
            if (TryParsePayload(out object rawPayload))
            {
                payload = rawPayload as T;

                return payload != null;
            }

            payload = null;

            return false;
        }
        #endregion
    }
}
