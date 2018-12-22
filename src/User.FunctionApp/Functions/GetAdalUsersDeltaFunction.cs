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
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get AAD users delta.
    /// </summary>
    public class GetAdalUsersDeltaFunction : FunctionBase<ILogger>, IGetAdalUsersDeltaFunction
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IGraphServiceHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAdalUsersDeltaFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="handler"><see cref="IAdalGraphServiceHandler"/> instance.</param>
        public GetAdalUsersDeltaFunction(AppSettings settings, IMapper mapper, IAdalGraphServiceHandler handler)
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
                var response = await this._handler
                                         .WithAdalCredential<ClientCredential>()
                                         .WithAdalClientApplication<AuthenticationContext>()
                                         .WithAdalProvider<AdalAuthenticationProvider>()
                                         .Build()
                                         .GetUsersDeltaAsync<AdalUser>()
                                         .MapAsync<AdalUser, AadUser>(this._mapper)
                                         .BuildResponseAync<AadUserCollectionResponse, AadUser>()
                                         .ConfigureAwait(false);

                result = new OkObjectResult(response);
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