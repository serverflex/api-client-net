using Newtonsoft.Json;
using ServerFlex.API.Schema;

namespace ServerFlex.API.Entities
{
    public class LockInfoEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the resource is locked.
        /// </summary>
        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the reason why the resource is locked, if any. See <see cref="LockReason" />.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
        #endregion
    }
}
