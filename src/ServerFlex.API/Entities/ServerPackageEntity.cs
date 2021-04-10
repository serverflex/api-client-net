using Newtonsoft.Json;
using ServerFlex.API.Schema;

namespace ServerFlex.API.Entities
{
    public class ServerPackageEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name. See <see cref="PackageName" />.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion
    }
}
