using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;
using Kda.User.FunctionApp.Models;
using Kda.User.FunctionApp.Providers;

using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Kda.User.FunctionApp.Handlers
{
    /// <summary>
    /// This represents the builder entity for the  class.
    /// </summary>
    public class AdalGraphServiceHandler : IAdalGraphServiceHandler
    {
        private const string Authority = "{0}/{1}";
        private const string ResourceUri = "https://graph.windows.net";

        private readonly AppSettings _settings;
        private readonly HttpClient _client;

        private ClientCredential _cc;
        private AuthenticationContext _ac;
        private IAuthenticationProvider _ap;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsalGraphServiceHandler"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="client"><see cref="HttpClient"/> instance.</param>
        public AdalGraphServiceHandler(AppSettings settings, HttpClient client)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc />
        public IGraphServiceHandler AddCredential()
        {
            this._cc = new ClientCredential(this._settings.Auth.ClientId, this._settings.Auth.ClientSecret);

            return this;
        }

        /// <inheritdoc />
        public IGraphServiceHandler AddClientApplication()
        {
            var authority = Authority.WithFormat(this._settings.Auth.BaseUri.TrimEnd('/'), this._settings.Auth.TenantId);
            this._ac = new AuthenticationContext(authority);

            return this;
        }

        /// <inheritdoc />
        public IGraphServiceHandler AddAuthenticationProvider()
        {
            this._ap = new AdalAuthenticationProvider(this._ac, this._cc);

            return this;
        }

        /// <inheritdoc />
        public IGraphServiceHandler Build()
        {
            return this;
        }

        /// <inheritdoc />
        public async Task<List<T>> GetUsersAsync<T>()
        {
            string url = $"{ResourceUri.TrimEnd('/')}/{this._settings.Auth.TenantId}/users?api-version=1.6";
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await this._client.SendAsync(request, this._ap).ConfigureAwait(false))
            {
                var users = await response.Content.ReadAsAsync<AdalUserCollection>().ConfigureAwait(false);

                return (List<T>)Convert.ChangeType(users.Value, typeof(List<T>));
            }
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