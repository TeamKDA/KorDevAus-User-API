using System;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;

using MailChimp.Net.Interfaces;

using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get user from MailChimp.
    /// </summary>
    public class GetMailChimpUserFunction : FunctionBase<ILogger>, IGetMailChimpUserFunction
    {
        private readonly AppSettings _settings;
        private readonly IMailChimpManager _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMailChimpUserFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        public GetMailChimpUserFunction(AppSettings settings, IMailChimpManager client)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            var users = await this._client.Members.GetAllAsync(this._settings.MailChimp.ListId).ConfigureAwait(false);
            var user = await this._client.Members.GetAsync(this._settings.MailChimp.ListId, emailAddressOrHash: "").ConfigureAwait(false);
            var result = await this._client.Members.AddOrUpdateAsync(this._settings.MailChimp.ListId, member: null).ConfigureAwait(false);

            var result2 = await this._client.Members.CreateMemberIfNotExistsAsync(this._settings.MailChimp.ListId, member: null).ConfigureAwait(false);

            // Create if not exists.

            return await base.InvokeAsync<TInput, TOutput>(input, options).ConfigureAwait(false);
        }
    }
}