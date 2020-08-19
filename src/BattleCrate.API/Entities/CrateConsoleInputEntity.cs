using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateConsoleInputEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the input for the console.
        /// </summary>
        [JsonProperty("input")]
        public string Input { get; set; }
        #endregion
    }
}
