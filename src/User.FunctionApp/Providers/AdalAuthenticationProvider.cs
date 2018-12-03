using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Kda.User.FunctionApp.Providers
{
    /// <summary>
    /// This represents the authentication provider entity for MSAL.
    /// </summary>
    public class AdalAuthenticationProvider : IAuthenticationProvider
    {
        private const string ResourceUri = "https://graph.windows.net";

        private readonly AuthenticationContext _context;
        private readonly ClientCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsalAuthenticationProvider"/> class.
        /// </summary>
        /// <param name="context"><see cref="AuthenticationContext"/> instance.</param>
        /// <param name="credential"><see cref="ClientCredential"/> instance.</param>
        public AdalAuthenticationProvider(AuthenticationContext context, ClientCredential credential)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._credential = credential ?? throw new ArgumentNullException(nameof(credential));
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
            var result = await this._context
                                   .AcquireTokenAsync(ResourceUri, this._credential)
                                   .ConfigureAwait(false);

            return result.AccessToken;
        }
    }
}