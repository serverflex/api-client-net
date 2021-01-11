using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerPackageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the server Package's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the server Package's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the server Plans available with this server Package.
        /// </summary>
        [JsonProperty("plans")]
        public ServerPlanEntity[] Plans { get; set; }

        /// <summary>
        /// Gets or sets the Regions that this server Package can be deployed to.
        /// </summary>
        [JsonProperty("regions")]
        public RegionEntity[] Regions { get; set; }

        /// <summary>
        /// Gets or sets the server Runtimes available for this server Package.
        /// </summary>
        [JsonProperty("runtimes")]
        public ServerRuntimeEntity[] Runtimes { get; set; }
        #endregion
    }
}
