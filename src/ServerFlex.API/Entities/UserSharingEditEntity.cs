using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class UserSharingEditEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the permission level.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }
        #endregion
    }
}
