using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Graph;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extensions entity for the <see cref="HttpClient"/> class.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="client"><see cref="HttpClient"/> instance.</param>
        /// <param name="request"><see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="provider"><see cref="IAuthenticationProvider"/> instance.</param>
        /// <returns><see cref="HttpResponseMessage"/> instance.</returns>
        public static async Task<HttpResponseMessage> SendAsync(this HttpClient client, HttpRequestMessage request, IAuthenticationProvider provider)
        {
            await provider.AuthenticateRequestAsync(request).ConfigureAwait(false);

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return response;
        }
    }
}