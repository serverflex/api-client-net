using Newtonsoft.Json;
using System;

namespace ServerFlex.API.Entities
{
    public class RegionEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets when capacity is expected, or null if the region is in-stock.
        /// </summary>
        [JsonProperty("capacityExpected")]
        public DateTime? CapacityExpected { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the Region's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
