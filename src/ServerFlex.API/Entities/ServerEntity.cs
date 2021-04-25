using Newtonsoft.Json;
using ServerFlex.API.Schema;
using System;

namespace ServerFlex.API.Entities
{
    public class ServerEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the billing type.
        /// </summary>
        [JsonProperty("billingType")]
        public string BillingType { get; set; }

        /// <summary>
        /// Gets or sets the time created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the locked state for this Crate.
        /// </summary>
        [JsonProperty("locked")]
        public LockInfoEntity Locked { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the network information for the server.
        /// </summary>
        [JsonProperty("network")]
        public NetworkInfoEntity Network { get; set; }

        /// <summary>
        /// Gets or sets the package.
        /// </summary>
        [JsonProperty("package")]
        public ServerPackageEntity Package { get; set; }

        /// <summary>
        /// Gets or sets the current users permission level on this server.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        [JsonProperty("plan")]
        public ServerPlanEntity Plan { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        [JsonProperty("region")]
        public RegionEntity Region { get; set; }

        /// <summary>
        /// Gets or sets the runtimes running on this server.
        /// </summary>
        [JsonProperty("runtimes")]
        public ServerRuntimeEntity[] Runtimes { get; set; }

        /// <summary>
        /// Gets or sets the current state. <see cref="ServerState" />.
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
