using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePlayersEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the number of players currently connected to the Crate.
        /// </summary>
        [JsonProperty("online")]
        public int OnlineCount { get; set; }
        #endregion
    }
}
