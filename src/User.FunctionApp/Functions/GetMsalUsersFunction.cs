using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;
using Kda.User.FunctionApp.Handlers;
using Kda.User.FunctionApp.Models;
using Kda.User.FunctionApp.Providers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get AAD users.
    /// </summary>
    public class GetMsalUsersFunction : FunctionBase<ILogger>, IGetMsalUsersFunction
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IGraphServiceHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMsalUsersFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="handler"><see cref="IMsalGraphServiceHandler"/> instance.</param>
        public GetMsalUsersFunction(AppSettings settings, IMapper mapper, IMsalGraphServiceHandler handler)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var result = (IActionResult)null;
            try
            {
                var users = await this._handler
                                      .WithMsalCredential<ClientCredential>()
                                      .WithMsalClientApplication<ConfidentialClientApplication>()
                                      .WithMsalProvider<MsalAuthenticationProvider>()
                                      .Build()
                                      .GetUsersAsync<Microsoft.Graph.User>()
                                      .ConfigureAwait(false);

                result = new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var value = new ErrorResponse(statusCode, ex.Message);

                result = new ObjectResult(value) { StatusCode = statusCode };
            }

            return (TOutput)result;
        }
    }
}