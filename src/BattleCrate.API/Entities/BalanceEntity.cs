using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class BalanceEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the amount of currency.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency, in ISO 4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        #endregion
    }
}
