using Newtonsoft.Json;
using System;

namespace BattleCrate.API.Entities
{
    public class CrateEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the billing type.
        /// </summary>
        [JsonProperty("bilingType")]
        public string BillingType { get; set; }

        /// <summary>
        /// Gets or sets the time that the Crate was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the locked state for this Crate.
        /// </summary>
        [JsonProperty("locked")]
        public CrateLockInfoEntity Locked { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the network information for the Crate.
        /// </summary>
        [JsonProperty("network")]
        public NetworkInfoEntity Network { get; set; }

        /// <summary>
        /// Gets or sets the Crate's Crate Package.
        /// </summary>
        [JsonProperty("package")]
        public CratePackageEntity Package { get; set; }

        /// <summary>
        /// Gets or sets the current user's permission level on this Crate.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the Crate's Crate Plan.
        /// </summary>
        [JsonProperty("plan")]
        public CratePlanEntity Plan { get; set; }

        /// <summary>
        /// Gets or sets the Region where the Crate is deployed.
        /// </summary>
        [JsonProperty("region")]
        public RegionEntity Region { get; set; }

        /// <summary>
        /// Gets or sets the Crate Runtimes running on this Crate.
        /// </summary>
        [JsonProperty("runtimes")]
        public CrateRuntimeEntity[] Runtimes { get; set; }

        /// <summary>
        /// Gets or sets the Crate's current state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Crate's UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }
        #endregion
    }
}
