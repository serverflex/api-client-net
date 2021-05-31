using ServerFlex.API.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServerFlex.API.Authentication
{
    public interface IApiAuthentication
    {
        #region Events
        event EventHandler Reauthorized;
        #endregion

        #region Methods
        /// <summary>
        /// Applies the authentication to an outgoing request.
        /// </summary>
        /// <param name="request">The outgoing request.</param>
        void ApplyToRequest(HttpRequestMessage request);

        /// <summary>
        /// Deserializes previously serialized authentication and applies it.
        /// </summary>
        /// <param name="serializedAuthentication">The serialized authentication.</param>
        void Deserialize(string serializedAuthentication);

        /// <summary>
        /// Attempts to reauthorize.
        /// </summary>
        /// <param name="apiRequestor">The API requestor.</param>
        Task<bool> ReauthorizeAsync(IApiRequestor apiRequestor);

        /// <summary>
        /// Serializes the authentication for persistant storage.
        /// </summary>
        string Serialize();
        #endregion
    }
}
