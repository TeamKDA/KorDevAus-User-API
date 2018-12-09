using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kda.User.FunctionApp.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="DbUserService"/> class.
    /// </summary>
    public interface IDbUserService : IDisposable
    {
        /// <summary>
        /// Gets the all list of users.
        /// </summary>
        /// <returns>All list of users.</returns>
        Task<List<KorDevAus.Entities.User>> GetAllUsersAsync();

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <returns>The user.</returns>
        Task<KorDevAus.Entities.User> GetUserAsync(Guid id);

        /// <summary>
        /// Upserts the list of users.
        /// </summary>
        /// <param name="users">List of users.</param>
        /// <returns>List of users upserted.</returns>
        Task<List<KorDevAus.Entities.User>> UpsertUsersAsync(IEnumerable<KorDevAus.Entities.User> users);

        /// <summary>
        /// Upserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The user upserted.</returns>
        Task<KorDevAus.Entities.User> UpsertUserAsync(KorDevAus.Entities.User user);
    }
}