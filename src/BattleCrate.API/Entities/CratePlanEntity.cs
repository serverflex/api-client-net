using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePlanEntity
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
        /// Gets or sets the name of the Crate Package that the Plan belongs to.
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the pricing for the Plan. The array contains all available currencies. Depending on where the Plan was requested, pricing may not be included.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingEntity[] Pricing { get; set; }

        /// <summary>
        /// Gets or sets the name of the Region that this Plan can be deployed to, if specific. Otherwise, null.
        /// </summary>
        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets the resources available to this Crate Plan.
        /// </summary>
        [JsonProperty("resources")]
        public CratePlanResourcesEntity Resources { get; set; }
        #endregion
    }
}
