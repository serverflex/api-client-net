using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerPlanEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Plan's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the Plan's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pricing for the Plan.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingEntity Pricing { get; set; }

        /// <summary>
        /// Gets or sets the resources available to this server Plan.
        /// </summary>
        [JsonProperty("resources")]
        public ServerPlanResourcesEntity Resources { get; set; }
        #endregion
    }
}
