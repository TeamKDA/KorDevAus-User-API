using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kda.User.FunctionApp.Extensions;

using KorDevAus.Repositories;

namespace Kda.User.FunctionApp.Services
{
    /// <summary>
    /// This represents the service entity for DB Users.
    /// </summary>
    public class DbUserService : IDbUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupUserRepository groupUserRepository;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbUserService"/> class.
        /// </summary>
        /// <param name="userRepository"><see cref="IUserRepository"/> instance.</param>
        /// <param name="groupRepository"><see cref="IGroupRepository"/> instance.</param>
        /// <param name="groupUserRepository"><see cref="IGroupUserRepository"/> instance.</param>
        public DbUserService(IUserRepository userRepository, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository)
        {
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            this.groupUserRepository = groupUserRepository ?? throw new ArgumentNullException(nameof(groupUserRepository));
        }

        /// <inheritdoc />
        public async Task<List<KorDevAus.Entities.User>> GetAllUsersAsync()
        {
            var users = await this._userRepository.GetAllAsync().ConfigureAwait(false);

            return users;
        }

        /// <inheritdoc />
        public async Task<KorDevAus.Entities.User> GetUserAsync(Guid id)
        {
            var user = await this._userRepository.GetAsync(id).ConfigureAwait(false);

            return user;
        }

        /// <inheritdoc />
        public async Task<List<KorDevAus.Entities.User>> UpsertUsersAsync(IEnumerable<KorDevAus.Entities.User> users)
        {
            await this._userRepository.UpsertRangeAsync(users).ConfigureAwait(false);

            var upsertedUsers = (await this.GetAllUsersAsync().ConfigureAwait(false))
                                    .Where(p => users.Select(q => q.Email).ContainsEquivalentTo(p.Email))
                                    .ToList();

            return upsertedUsers;
        }

        /// <inheritdoc />
        public async Task<KorDevAus.Entities.User> UpsertUserAsync(KorDevAus.Entities.User user)
        {
            await this._userRepository.UpsertAsync(user).ConfigureAwait(false);

            var upsertedUser = (await this.GetAllUsersAsync().ConfigureAwait(false))
                                   .SingleOrDefault(p => p.Email.IsEquivalentTo(user.Email));

            return upsertedUser;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Value indicating whether to dispose managed and/or unmanaged resources or not.</param>
        protected void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed resources.
            }

            // Dispose unmanaged resources.

            this._disposed = true;
        }
    }
}