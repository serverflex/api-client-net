using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ReferralOverviewEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the number of referred users.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the currency code, in ISO 4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the total earnings from referrals.
        /// </summary>
        [JsonProperty("earnings")]
        public double Earnings { get; set; }
        #endregion
    }
}
