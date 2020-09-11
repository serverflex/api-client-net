using Newtonsoft.Json;
using System;

namespace BattleCrate.API.Entities
{
    public class UserBasicEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the user's family (last) name.
        /// </summary>
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the user's given (first) name.
        /// </summary>
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }
        #endregion
    }
}
