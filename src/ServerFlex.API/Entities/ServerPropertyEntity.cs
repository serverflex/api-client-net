using Newtonsoft.Json;

namespace ServerFlex.API.Entities
{
    public class ServerPropertyEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the accepted values, if any.
        /// </summary>
        [JsonProperty("acceptedValues")]
        public AcceptedValueEntity[] AcceptedValues { get; set; }
        
        /// <summary>
        /// Gets or sets the category name, if any.
        /// </summary>
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the default value, if any.
        /// </summary>
        [JsonProperty("default")]
        public object Default { get; set; }

        /// <summary>
        /// Gets or sets the setting name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether a value is required to modify this property.
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the value type. See <see cref="Schema.ValueType" />.
        /// </summary>
        [JsonProperty("valueType")]
        public string ValueType { get; set; }
        #endregion
    }
}
