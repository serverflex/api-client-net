using BattleCrate.API.Schema;
using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateLockInfoEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the Crate is locked.
        /// </summary>
        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the reason why the Crate is locked, if any. See <see cref="LockReason" />.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
        #endregion
    }
}
