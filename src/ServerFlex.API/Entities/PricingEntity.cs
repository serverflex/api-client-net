using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class PricingEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the hourly cost.
        /// </summary>
        [JsonProperty("costHourly")]
        public decimal CostHourly { get; set; }

        /// <summary>
        /// Gets or sets the monthly cost.
        /// </summary>
        [JsonProperty("costMonthly")]
        public decimal CostMonthly { get; set; }

        /// <summary>
        /// Gets or sets the currency code, in ISO 4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        #endregion
    }
}
