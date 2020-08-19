using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class UserSharingNewEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the permission level.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        #endregion
    }
}
