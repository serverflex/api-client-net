using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class PackageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the plans.
        /// </summary>
        [JsonProperty("plans")]
        public PackagePlanEntity[] Plans { get; set; }

        /// <summary>
        /// Gets or sets the runtimes available for a package.
        /// </summary>
        [JsonProperty("runtimes")]
        public ServerRuntimeEntity[] Runtimes { get; set; }

        /// <summary>
        /// Gets or sets a list of Regions this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("regions")]
        public RegionEntity[] Regions { get; set; }
        #endregion
    }
}
