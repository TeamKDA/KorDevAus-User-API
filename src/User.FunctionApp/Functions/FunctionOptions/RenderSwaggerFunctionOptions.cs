using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

namespace Kda.User.FunctionApp.Functions.FunctionOptions
{
    /// <summary>
    /// This represents the function option entity for the <see cref="RenderSwaggerFunction"/> class.
    /// </summary>
    public class RenderSwaggerFunctionOptions : FunctionOptionsBase
    {
        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        public string Extension { get; set; }
    }
}