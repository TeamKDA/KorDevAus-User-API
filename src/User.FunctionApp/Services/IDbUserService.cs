using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Kda.User.FunctionApp.Models;

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
        /// Gets the user with the given email.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <returns>The user.</returns>
        Task<KorDevAus.Entities.User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Upserts the list of users.
        /// </summary>
        /// <param name="users">List of <see cref="DbUser"/> instances.</param>
        /// <returns>List of <see cref="KorDevAus.Entities.User"/> instances upserted.</returns>
        Task<List<KorDevAus.Entities.User>> UpsertUsersAsync(IEnumerable<DbUser> users);

        /// <summary>
        /// Upserts the user.
        /// </summary>
        /// <param name="user">The <see cref="DbUser"/> instance.</param>
        /// <returns>The <see cref="KorDevAus.Entities.User"/> instance upserted.</returns>
        Task<KorDevAus.Entities.User> UpsertUserAsync(DbUser user);
    }
}