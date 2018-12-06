using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kda.User.FunctionApp.Handlers
{
    /// <summary>
    /// This provides interfaces to the MailChimp service handler class.
    /// </summary>
    public interface IMailChimpServiceHandler : IDisposable
    {
        /// <summary>
        /// Builds handler.
        /// </summary>
        /// <returns><see cref="IMailChimpServiceHandler"/> instance.</returns>
        IMailChimpServiceHandler Build();

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <typeparam name="T">Type of user in the collection.</typeparam>
        /// <returns>List of the users.</returns>
        Task<List<T>> GetUsersAsync<T>();

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <typeparam name="T">Type of user.</typeparam>
        /// <param name="id">MailChimp Id.</param>
        /// <returns>User instance.</returns>
        Task<T> GetUserAsync<T>(string id);

        /// <summary>
        /// Adds or updates the list of users.
        /// </summary>
        /// <typeparam name="T">Type of user.</typeparam>
        /// <param name="users">List of user instances.</param>
        /// <returns>List of user instances added/updated.</returns>
        Task<List<T>> AddOrUpdateUsersAsync<T>(List<T> users);
    }
}