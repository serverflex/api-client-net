using Newtonsoft.Json;
using System;

namespace ServerFlex.API.Entities
{
    public class ServerEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the billing type.
        /// </summary>
        [JsonProperty("bilingType")]
        public string BillingType { get; set; }

        /// <summary>
        /// Gets or sets the time that the server was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the locked state for this server.
        /// </summary>
        [JsonProperty("locked")]
        public ServerLockInfoEntity Locked { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the network information for the server.
        /// </summary>
        [JsonProperty("network")]
        public NetworkInfoEntity Network { get; set; }

        /// <summary>
        /// Gets or sets the server's server Package.
        /// </summary>
        [JsonProperty("package")]
        public ServerPackageEntity Package { get; set; }

        /// <summary>
        /// Gets or sets the current user's permission level on this server.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the server's server Plan.
        /// </summary>
        [JsonProperty("plan")]
        public ServerPlanEntity Plan { get; set; }

        /// <summary>
        /// Gets or sets the Region where the server is deployed.
        /// </summary>
        [JsonProperty("region")]
        public RegionEntity Region { get; set; }

        /// <summary>
        /// Gets or sets the server Runtimes running on this server.
        /// </summary>
        [JsonProperty("runtimes")]
        public ServerRuntimeEntity[] Runtimes { get; set; }

        /// <summary>
        /// Gets or sets the server's current state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the server's UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }
        #endregion
    }
}
