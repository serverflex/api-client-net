using System;
using System.Net.Http;

namespace ServerFlex.API
{
    public sealed class ApiException : Exception
    {
        #region Properties
        /// <summary>
        /// Gets the relevant errors, or empty.
        /// </summary>
        public ApiError Error { get; }

        /// <summary>
        /// Gets the response message that generated the exception, if any.
        /// </summary>
        public HttpResponseMessage ResponseMessage { get; private set; }
        #endregion

        #region Constructors
        public ApiException()
            : this(null)
        {
        }

        public ApiException(string message)
            : this(message, null)
        {
        }

        public ApiException(string message, Exception innerException)
            : this(message, innerException, null, null)
        {
        }

        public ApiException(string message, HttpResponseMessage responseMessage, ApiError error)
            : this(message, null, responseMessage, error)
        {
        }

        public ApiException(string message, Exception innerException, HttpResponseMessage responseMessage, ApiError error)
            : base(message, innerException)
        {
            Error = error;
            ResponseMessage = responseMessage;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// A formatted 'invalid server response' API exception.
        /// </summary>
        /// <param name="responseMessage">The response that generated the exception.</param>
        internal static ApiException InvalidServerResponse(HttpResponseMessage responseMessage)
        {
            return new ApiException($"Invalid server response: {(int)responseMessage.StatusCode} {responseMessage.StatusCode}.", responseMessage, null);
        }
        #endregion
    }
}
