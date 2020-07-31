using Newtonsoft.Json;
using System;

namespace BattleCrate.API.Entities
{
    public class CrateEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the time created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the locked state for this Crate.
        /// </summary>
        [JsonProperty("locked")]
        public CrateLockInfoEntity Locked { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the network information for a Crate.
        /// </summary>
        [JsonProperty("network")]
        public NetworkInfoEntity Network { get; set; }

        /// <summary>
        /// Gets or sets the package.
        /// </summary>
        [JsonProperty("package")]
        public CratePackageEntity Package { get; set; }

        /// <summary>
        /// Gets or sets the current users permission level on this Crate.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        [JsonProperty("plan")]
        public CratePlanEntity Plan { get; set; }

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        [JsonProperty("profile")]
        public CrateProfileEntity Profile { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        [JsonProperty("region")]
        public RegionEntity Region { get; set; }

        /// <summary>
        /// Gets or sets the current state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }
        #endregion
    }
}
