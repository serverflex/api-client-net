using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServerFlex.API.Entities
{
    public class ServerDeployEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the billing type.
        /// </summary>
        [JsonProperty("billingType")]
        public string BillingType { get; set; }

        /// <summary>
        /// Gets or sets the name for the new server.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the server Package to deploy to the new server.
        /// </summary>
        [JsonProperty("package")]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server Plan that should be used for the new server.
        /// </summary>
        [JsonProperty("plan")]
        public string PlanName { get; set; }

        /// <summary>
        /// Gets or sets any properties required to deploy the server.
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }

        /// <summary>
        /// Gets or sets the name of the Region where the new server should be deployed.
        /// </summary>
        [JsonProperty("region")]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets the runtimes that should be used for the new server.
        /// </summary>
        [JsonProperty("runtimes")]
        public string[] Runtimes { get; set; }
        #endregion
    }
}
