using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

namespace Kda.User.FunctionApp.Functions.FunctionOptions
{
    /// <summary>
    /// This represents the options entity for the <see cref="GetMailChimpUserFunction"/> class.
    /// </summary>
    public class GetMailChimpUserFunctionOptions : FunctionOptionsBase
    {
        /// <summary>
        /// Gets or sets the MailChimp user Id.
        /// </summary>
        public string UserId { get; set; }
    }
}