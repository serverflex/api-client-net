using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateCommandEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the command to input into the Crate's console.
        /// </summary>
        [JsonProperty("input")]
        public string Command { get; set; }
        #endregion
    }
}
