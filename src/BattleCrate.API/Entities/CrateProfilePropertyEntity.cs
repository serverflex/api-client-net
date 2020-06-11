using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class CrateProfilePropertyEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the accepted values for the property, if any.
        /// </summary>
        [JsonProperty("acceptedValues")]
        public object[] AcceptedValues { get; set; }

        /// <summary>
        /// Gets or sets the default value for the property, if any.
        /// </summary>
        [JsonProperty("default")]
        public object Default { get; set; }

        /// <summary>
        /// Gets or sets the unique name of the property.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the field must be provided.
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the type of field that is required. See <see cref="Schema.ValueType" />.
        /// </summary>
        [JsonProperty("valueType")]
        public string ValueType { get; set; }
        #endregion
    }
}
