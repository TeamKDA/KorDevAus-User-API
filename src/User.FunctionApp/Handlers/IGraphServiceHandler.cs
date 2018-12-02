using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kda.User.FunctionApp.Handlers
{
    /// <summary>
    /// This provides interfaces to the <see cref="GraphServiceHandler"/> class.
    /// </summary>
    public interface IGraphServiceHandler : IDisposable
    {
        /// <summary>
        /// Adds credential.
        /// </summary>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        IGraphServiceHandler AddCredential();

        /// <summary>
        /// Adds client application.
        /// </summary>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        IGraphServiceHandler AddClientApplication();

        /// <summary>
        /// Adds authentication provider.
        /// </summary>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        IGraphServiceHandler AddAuthenticationProvider();

        /// <summary>
        /// Builds handler.
        /// </summary>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        IGraphServiceHandler Build();

        /// <summary>
        /// Gets the list of <see cref="Microsoft.Graph.User"/> instances.
        /// </summary>
        /// <returns></returns>
        Task<List<Microsoft.Graph.User>> GetUsersAsync();
    }
}