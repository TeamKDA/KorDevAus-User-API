using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Kda.User.FunctionApp.Models;

using KorDevAus.Entities;
using KorDevAus.Repositories;

namespace Kda.User.FunctionApp.Services
{
    /// <summary>
    /// This represents the service entity for DB Users.
    /// </summary>
    public class DbUserService : IDbUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupUserRepository groupUserRepository;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbUserService"/> class.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="userRepository"><see cref="IUserRepository"/> instance.</param>
        /// <param name="groupRepository"><see cref="IGroupRepository"/> instance.</param>
        /// <param name="groupUserRepository"><see cref="IGroupUserRepository"/> instance.</param>
        public DbUserService(IMapper mapper, IUserRepository userRepository, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
        public async Task<List<KorDevAus.Entities.User>> GetUsersByEmailsAsync(IEnumerable<string> emails)
        {
            var users = await this._userRepository.GetByEmailsAsync(emails).ConfigureAwait(false);

            return users;
        }

        /// <inheritdoc />
        public async Task<KorDevAus.Entities.User> GetUserByEmailAsync(string email)
        {
            var user = await this._userRepository.GetByEmailAsync(email).ConfigureAwait(false);

            return user;
        }

        /// <inheritdoc />
        public async Task<List<KorDevAus.Entities.User>> UpsertUsersAsync(IEnumerable<DbUser> users)
        {
            var upsertedUsers = new List<KorDevAus.Entities.User>();
            var now = DateTimeOffset.UtcNow;
            var group = await this._groupRepository.GetByNameAsync("Users").ConfigureAwait(false);

            foreach (var user in users)
            {
                var dbUser = await this.BuildUserAsync(user, group.Id, now).ConfigureAwait(false);
                upsertedUsers.Add(dbUser);
            }

            await this._userRepository.UpsertRangeAsync(upsertedUsers).ConfigureAwait(false);

            var processedUsers = await this.GetUsersByEmailsAsync(users.Select(p => p.Email)).ConfigureAwait(false);

            return processedUsers;
        }

        /// <inheritdoc />
        public async Task<KorDevAus.Entities.User> UpsertUserAsync(DbUser user)
        {
            var now = DateTimeOffset.UtcNow;
            var group = await this._groupRepository.GetByNameAsync("Users").ConfigureAwait(false);
            var upsertedUser = await this.BuildUserAsync(user, group.Id, now).ConfigureAwait(false);

            await this._userRepository.UpsertAsync(upsertedUser).ConfigureAwait(false);

            var processedUser = await this.GetUserByEmailAsync(user.Email).ConfigureAwait(false);

            return processedUser;
        }

        private async Task<KorDevAus.Entities.User> BuildUserAsync(DbUser user, Guid groupId, DateTimeOffset now)
        {
            var gu = (GroupUser)null;
            var userId = Guid.NewGuid();

            var dbUser = await this._userRepository.GetByEmailAsync(user.Email).ConfigureAwait(false);
            if (dbUser == null)
            {
                dbUser = this._mapper.Map<KorDevAus.Entities.User>(user);
                dbUser.Id = userId;
                dbUser.DateCreated = now;

                gu = new GroupUser()
                         {
                             Id = Guid.NewGuid(),
                             UserId = userId,
                             GroupId = groupId,
                             DateJoined = user.DateJoined.GetValueOrDefault(now)
                         };

                dbUser.GroupUsers = new[] { gu }.ToList();

                return dbUser;
            }

            userId = dbUser.Id;
            dbUser = this._mapper.Map<DbUser, KorDevAus.Entities.User>(user, dbUser);
            dbUser.Id = userId;

            if (dbUser.GroupUsers == null)
            {
                dbUser.GroupUsers = new List<GroupUser>();
            }

            gu = dbUser.GroupUsers.SingleOrDefault(p => p.GroupId == groupId);
            if (gu == null)
            {
                gu = new GroupUser()
                         {
                             Id = Guid.NewGuid(),
                             UserId = userId,
                             GroupId = groupId,
                             DateJoined = user.DateJoined.GetValueOrDefault(now)
                         };

                dbUser.GroupUsers.Add(gu);
            }

            dbUser.DateUpdated = now;

            return dbUser;
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