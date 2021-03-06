﻿using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class BalanceEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the amount of currency.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency code, in ISO 4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        #endregion
    }
}
