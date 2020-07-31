using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleCrate.API.Entities
{
    public class CrateDeployEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name for the new Crate.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the plan that should be used for this Crate.
        /// </summary>
        [JsonProperty("plan")]
        public string PlanName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Profile that should be used to configure the Crate.
        /// </summary>
        [JsonProperty("profile")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets any properties required to deploy the Crate.
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }

        /// <summary>
        /// Gets or sets the name of the Region where the Crate should be deployed.
        /// </summary>
        [JsonProperty("region")]
        public string RegionName { get; set; }
        #endregion
    }
}
