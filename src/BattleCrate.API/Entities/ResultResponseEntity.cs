using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class ResultResponseEntity<TEntity>
    {
        #region Properties
        /// <summary>
        /// Gets or sets the limit for each page.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the result objects.
        /// </summary>
        [JsonProperty("results")]
        public TEntity[] Results { get; set; }

        /// <summary>
        /// Gets or sets the total number of available pages.
        /// </summary>
        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total number of results, not just those on this page.
        /// </summary>
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
        #endregion
    }
}
