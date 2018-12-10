using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;
using Kda.User.FunctionApp.Functions.FunctionOptions;
using Kda.User.FunctionApp.Models;
using Kda.User.FunctionApp.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get users from MailChimp.
    /// </summary>
    public class GetDbUserFunction : FunctionBase<ILogger>, IGetDbUserFunction
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IDbUserService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDbUserFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="service"><see cref="IDbUserService"/> instance.</param>
        public GetDbUserFunction(AppSettings settings, IMapper mapper, IDbUserService service)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var result = (IActionResult)null;

            var opt = options as GetDbUserFunctionOptions;
            if (opt == null)
            {
                var statusCode = (int)HttpStatusCode.BadRequest;
                var value = new ErrorResponse(statusCode, "Options not set");

                result = new ObjectResult(value) { StatusCode = statusCode };

                return (TOutput)result;
            }

            try
            {
                var response = await this._service
                                         .GetUserAsync(opt.UserId)
                                         .MapAsync<KorDevAus.Entities.User, DbUser>(this._mapper)
                                         .BuildResponseAync<DbUserResponse, DbUser>()
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