using Newtonsoft.Json;
using ServerFlex.API.Schema;
using System.Collections.Generic;

namespace ServerFlex.API.Entities
{
    public class ServerDeployEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the billing type. See <see cref="Schema.BillingType" />.
        /// </summary>
        [JsonProperty("billingType")]
        public string BillingType { get; set; }

        /// <summary>
        /// Gets or sets the name for the new server.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the package to deploy. See <see cref="Schema.PackageName" />.
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the name of the plan to use for the server. See <see cref="Schema.PlanName" />.
        /// </summary>
        [JsonProperty("planName")]
        public string PlanName { get; set; }

        /// <summary>
        /// Gets or sets the runtimes that should be used for this server. See <see cref="ServerRuntime" />.
        /// </summary>
        [JsonProperty("runtimes")]
        public string[] Runtimes { get; set; }

        /// <summary>
        /// Gets or sets any properties required to deploy the server. See <see cref="PackagePropertyName" />.
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }

        /// <summary>
        /// Gets or sets the name of the region where the server should be deployed.
        /// </summary>
        [JsonProperty("regionName")]
        public string RegionName { get; set; }
        #endregion
    }
}
