using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace Kda.User.FunctionApp.Providers
{
    /// <summary>
    /// This represents the authentication provider entity for MSAL.
    /// </summary>
    /// <remarks>https://github.com/microsoftgraph/dotnetcore-console-sample/blob/master/base-console-app/Helpers/MsalAuthenticationProvider.cs</remarks>
    public class MsalAuthenticationProvider : IAuthenticationProvider
    {
        private const string DefaultScope = ".default";

        private ConfidentialClientApplication _cca;
        private IEnumerable<string> _scopes;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsalAuthenticationProvider"/> class.
        /// </summary>
        /// <param name="cca"><see cref="ConfidentialClientApplication"/> instance.</param>
        /// <param name="scopes">List of scopes for AAD access.</param>
        public MsalAuthenticationProvider(ConfidentialClientApplication cca, IEnumerable<string> scopes = null)
        {
            this._cca = cca ?? throw new ArgumentNullException(nameof(cca));
            this._scopes = scopes ?? new[] { DefaultScope };
        }

        /// <summary>
        /// Authenticates the specified request message.
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/> instance.</param>
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var token = await this.GetTokenAsync().ConfigureAwait(false);

            request.Headers.Authorization = new AuthenticationHeaderValue("BEARER", token);
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <returns>Access token.</returns>
        public async Task<string> GetTokenAsync()
        {
            var result = await this._cca
                                   .AcquireTokenForClientAsync(this._scopes)
                                   .ConfigureAwait(false);

            return result.AccessToken;
        }
    }
}