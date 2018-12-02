using Newtonsoft.Json;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the model entity for errors.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        public ErrorResponse(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        [JsonProperty(Order = 1)]
        public virtual int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty(Order = 2)]
        public virtual string Message { get; set; }
    }
}