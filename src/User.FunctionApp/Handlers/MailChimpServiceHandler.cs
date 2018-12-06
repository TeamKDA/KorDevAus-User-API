using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;

using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

namespace Kda.User.FunctionApp.Handlers
{
    /// <summary>
    /// This represents the handler entity for MailChimp service.
    /// </summary>
    public class MailChimpServiceHandler : IMailChimpServiceHandler
    {
        private readonly AppSettings _settings;
        private readonly IMailChimpManager _client;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MailChimpServiceHandler"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="client"><see cref="IMailChimpManager"/> instance.</param>
        public MailChimpServiceHandler(AppSettings settings, IMailChimpManager client)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc />
        public IMailChimpServiceHandler Build()
        {
            return this;
        }

        /// <inheritdoc />
        public async Task<List<T>> GetUsersAsync<T>()
        {
            var users = await this._client
                                  .Members
                                  .GetAllAsync(this._settings.MailChimp.ListId)
                                  .ConfigureAwait(false);

            return (List<T>)Convert.ChangeType(users.ToList(), typeof(List<T>));
        }

        /// <inheritdoc />
        public async Task<T> GetUserAsync<T>(string id)
        {
            var user = await this._client
                                 .Members
                                 .GetAsync(this._settings.MailChimp.ListId, id)
                                 .ConfigureAwait(false);

            return (T)Convert.ChangeType(user, typeof(T));
        }

        /// <inheritdoc />
        public async Task<List<T>> AddOrUpdateUsersAsync<T>(List<T> users)
        {
            var results = new List<T>();
            foreach (var user in users)
            {
                var result = await this._client
                                       .Members
                                       .CreateMemberIfNotExistsAsync(this._settings.MailChimp.ListId, (Member)Convert.ChangeType(user, typeof(Member)))
                                       .ConfigureAwait(false);

                results.Add((T)Convert.ChangeType(result, typeof(T)));
            }

            return results;
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

            if (!disposing)
            {
                return;
            }

            this._disposed = true;
        }
    }
}