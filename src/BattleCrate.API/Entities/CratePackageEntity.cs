using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CratePackageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Crate Package's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the Crate Package's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Crate Plans available with this Crate Package.
        /// </summary>
        [JsonProperty("plans")]
        public CratePlanEntity[] Plans { get; set; }

        /// <summary>
        /// Gets or sets the Regions that this Crate Package can be deployed to.
        /// </summary>
        [JsonProperty("regions")]
        public RegionEntity[] Regions { get; set; }

        /// <summary>
        /// Gets or sets the Crate Runtimes available for this Crate Package.
        /// </summary>
        [JsonProperty("runtimes")]
        public CrateRuntimeEntity[] Runtimes { get; set; }
        #endregion
    }
}
