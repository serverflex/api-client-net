using Newtonsoft.Json;
using System;

namespace BattleCrate.API.Entities
{
    public class CrateEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets when the Crate was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the Crate's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Crate's Crate Package.
        /// </summary>
        [JsonProperty("package")]
        public CratePackageEntity CratePackage { get; set; }

        /// <summary>
        /// Gets or sets your permission level over the Crate.
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the Crate's Plan.
        /// </summary>
        [JsonProperty("plan")]
        public CratePlanEntity Plan { get; set; }

        /// <summary>
        /// Gets or sets the Crate's Profile.
        /// </summary>
        [JsonProperty("profile")]
        public CrateProfileEntity Profile { get; set; }

        /// <summary>
        /// Gets or sets the Crate's Region.
        /// </summary>
        [JsonProperty("region")]
        public RegionEntity Region { get; set; }

        /// <summary>
        /// Gets or sets the Crate's state.
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
