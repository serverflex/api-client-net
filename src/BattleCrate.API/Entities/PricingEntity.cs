using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class PricingEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the hourly cost.
        /// </summary>
        [JsonProperty("costHourly")]
        public double CostHourly { get; set; }

        /// <summary>
        /// Gets or sets the monthly cost.
        /// </summary>
        [JsonProperty("costMonthly")]
        public double CostMonthly { get; set; }

        /// <summary>
        /// Gets or sets the currency code, in ISO 4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        #endregion
    }
}
