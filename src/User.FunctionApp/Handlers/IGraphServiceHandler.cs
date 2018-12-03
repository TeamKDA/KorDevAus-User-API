using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kda.User.FunctionApp.Handlers
{
    /// <summary>
    /// This provides interfaces to the graph service handler class.
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
        /// Gets the list of users.
        /// </summary>
        /// <typeparam name="T">Type of user in the collection.</typeparam>
        /// <returns>List of the users.</returns>
        Task<List<T>> GetUsersAsync<T>();
    }
}