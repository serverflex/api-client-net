using ServerFlex.API.Base;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServerFlex.API.Authentication.Base
{
    public abstract class BaseApiAuthentication : IApiAuthentication
    {
        #region Events
        public event EventHandler Reauthorized;
        #endregion

        #region Public Methods
        /// <summary>
        /// Applies the authentication to an outgoing request.
        /// </summary>
        /// <param name="request">The outgoing request.</param>
        public abstract void ApplyToRequest(HttpRequestMessage request);

        /// <summary>
        /// Deserialized previously serialized authentication and applies it.
        /// </summary>
        /// <param name="serializedAuthentication">The serialized authentication.</param>
        public void Deserialize(string serializedAuthentication)
        {
            using var memoryStream = new MemoryStream(Convert.FromBase64String(serializedAuthentication));

            DeserializeFromStream(memoryStream);
        }

        /// <summary>
        /// Attempts to reauthorize.
        /// </summary>
        /// <param name="apiRequestor">The API requestor.</param>
        public abstract Task<bool> ReauthorizeAsync(IApiRequestor apiRequestor);

        /// <summary>
        /// Serializes the authentication for persistant storage.
        /// </summary>
        public string Serialize()
        {
            using var memoryStream = new MemoryStream();

            SerializeToStream(memoryStream);

            return Convert.ToBase64String(memoryStream.ToArray());
        }
        #endregion

        #region Protected Methods
        protected abstract void DeserializeFromStream(Stream stream);

        protected void OnReauthorized()
        {
            Reauthorized?.Invoke(this, new EventArgs());
        }

        protected abstract void SerializeToStream(Stream stream);
        #endregion
    }
}
