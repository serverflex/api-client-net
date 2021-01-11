using ServerFlex.API.Schema;
using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerLockInfoEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the server is locked.
        /// </summary>
        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the reason why the server is locked, if any. See <see cref="LockReason" />.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
        #endregion
    }
}
