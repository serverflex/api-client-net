using Newtonsoft.Json;

namespace BattleCrate.API.Entities
{
    public class UserEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the family (last) name.
        /// </summary>
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the given (first) name(s).
        /// </summary>
        [JsonProperty("givenName")]
        public string GivenName { get; set; }
        #endregion
    }
}
