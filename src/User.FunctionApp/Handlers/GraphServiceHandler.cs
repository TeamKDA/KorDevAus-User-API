﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;
using Kda.User.FunctionApp.Providers;

using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace Kda.User.FunctionApp.Handlers
{
    /// <summary>
    /// This represents the builder entity for the <see cref="GraphServiceClient"/> class.
    /// </summary>
    public class GraphServiceHandler : IGraphServiceHandler
    {
        private const string Authority = "{0}/{1}/{2}";
        private const string Scope = "{0}/{1}";

        private readonly AppSettings _settings;

        private ClientCredential _cc;
        private ConfidentialClientApplication _cca;
        private IAuthenticationProvider _ap;
        private IGraphServiceClient _gsc;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphServiceHandler"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        public GraphServiceHandler(AppSettings settings)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <inheritdoc />
        public IGraphServiceHandler AddCredential()
        {
            this._cc = new ClientCredential(this._settings.Auth.ClientSecret);

            return this;
        }

        /// <inheritdoc />
        public IGraphServiceHandler AddClientApplication()
        {
            var authority = Authority.WithFormat(this._settings.Auth.BaseUri.TrimEnd('/'), this._settings.Auth.TenantId, this._settings.Auth.ApiVersion);
            this._cca = new ConfidentialClientApplication(this._settings.Auth.ClientId, authority, this._settings.Auth.RedirectUri, this._cc, null, null);

            return this;
        }

        /// <inheritdoc />
        public IGraphServiceHandler AddAuthenticationProvider()
        {
            var scopes = this._settings.Auth.Scopes.Select(p => Scope.WithFormat(this._settings.Auth.GraphUri, p));
            this._ap = new MsalAuthenticationProvider(this._cca, scopes);

            return this;
        }

        /// <inheritdoc />
        public IGraphServiceHandler Build()
        {
            this._gsc = new GraphServiceClient(this._ap);

            return this;
        }

        /// <inheritdoc />
        public async Task<List<Microsoft.Graph.User>> GetUsersAsync()
        {
            var result = await this._gsc.Users.Request().GetAsync().ConfigureAwait(false);
            var users = result.ToList();

            return users;
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