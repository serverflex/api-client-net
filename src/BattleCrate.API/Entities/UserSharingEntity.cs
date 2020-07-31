using Newtonsoft.Json;
using System;

namespace BattleCrate.API.Entities
{
    public class UserSharingEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets when sharing began.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the permission level.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [JsonProperty("user")]
        public UserBasicEntity User { get; set; }
        #endregion
    }
}
