using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleCrate.API.Entities
{
    public class RegionEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the Region can have services deployed to it.
        /// </summary>
        [JsonProperty("canDeploy")]
        public bool CanDeploy { get; set; }

        /// <summary>
        /// Gets or sets the Region's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the flag associated with the Region.
        /// </summary>
        [JsonProperty("flagUrl")]
        public Dictionary<int, string> FlagUrl { get; set; }

        /// <summary>
        /// Gets or sets the Region's unique name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
