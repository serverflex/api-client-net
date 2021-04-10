using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class PackagePlanEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the plan's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the plan's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pricing for the plan. The array contains all available currencies.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingEntity Pricing { get; set; }

        /// <summary>
        /// Gets or sets the resources for this plan.
        /// </summary>
        [JsonProperty("resources")]
        public PlanResourcesEntity Resources { get; set; }
        #endregion
    }
}
