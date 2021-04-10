using Newtonsoft.Json;

namespace ServerFlex.API
{
    public sealed class ApiError
    {
        #region Properties
        /// <summary>
        /// Gets the error.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; }

        /// <summary>
        /// Gets the errornous field, if any.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; }
        #endregion

        #region Constructors
        public ApiError(string code, string message)
        {
            Error = code;
            Field = message;
        }
        #endregion
    }
}
