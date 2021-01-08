using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleCrate.API.Entities
{
    public class CrateDeployEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the billing type.
        /// </summary>
        [JsonProperty("billingType")]
        public string BillingType { get; set; }

        /// <summary>
        /// Gets or sets the name for the new Crate.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Package to deploy to the new Crate.
        /// </summary>
        [JsonProperty("package")]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Crate Plan that should be used for the new Crate.
        /// </summary>
        [JsonProperty("plan")]
        public string PlanName { get; set; }

        /// <summary>
        /// Gets or sets any properties required to deploy the Crate.
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }

        /// <summary>
        /// Gets or sets the name of the Region where the new Crate should be deployed.
        /// </summary>
        [JsonProperty("region")]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets the runtimes that should be used for the new Crate.
        /// </summary>
        [JsonProperty("runtimes")]
        public string[] Runtimes { get; set; }
        #endregion
    }
}
