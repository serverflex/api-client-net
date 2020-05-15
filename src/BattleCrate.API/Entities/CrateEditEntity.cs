using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateEditEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the new name for the Crate.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
