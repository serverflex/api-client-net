using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerPlayersEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the number of players currently connected to the server.
        /// </summary>
        [JsonProperty("online")]
        public int Online { get; set; }

        /// <summary>
        /// Gets or sets the total number of slots available on the server, occupied or free.
        /// </summary>
        [JsonProperty("totalSlots")]
        public int TotalSlots { get; set; }
        #endregion
    }
}
