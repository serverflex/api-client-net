using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleCrate.API.Entities
{
    public class RegionEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether resources can be deployed to this Region.
        /// </summary>
        [JsonProperty("canDeploy")]
        public bool CanDeploy { get; set; }

        /// <summary>
        /// Gets or sets the Region's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the URLs for this Regions's flag, in size order.
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
