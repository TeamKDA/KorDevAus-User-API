using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="GetDbUsersFunction"/> class.
    /// </summary>
    public interface IGetDbUsersFunction : IFunction<ILogger>
    {
    }
}