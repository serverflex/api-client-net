using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateProfilePropertyValueEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value as a human-readable, displayable string.
        /// </summary>
        [JsonProperty("display")]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the group that this value belongs to, if any.
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }
        #endregion
    }
}
