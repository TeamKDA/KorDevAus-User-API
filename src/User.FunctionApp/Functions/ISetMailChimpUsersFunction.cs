using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="SetMailChimpUsersFunction"/> class.
    /// </summary>
    public interface ISetMailChimpUsersFunction : IFunction<ILogger>
    {
    }
}