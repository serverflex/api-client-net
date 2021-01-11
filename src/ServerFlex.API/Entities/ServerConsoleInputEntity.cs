using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerConsoleInputEntity
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
