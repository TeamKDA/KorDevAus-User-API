using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;
using Kda.User.FunctionApp.Models;
using Kda.User.FunctionApp.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to add users to MailChimp.
    /// </summary>
    public class AddDbUsersFunction : FunctionBase<ILogger>, IAddDbUsersFunction
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IDbUserService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddDbUsersFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="service"><see cref="IDbUserService"/> instance.</param>
        public AddDbUsersFunction(AppSettings settings, IMapper mapper, IDbUserService service)
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

            var req = input as HttpRequest;
            if (req == null)
            {
                var statusCode = (int)HttpStatusCode.BadRequest;
                var value = new ErrorResponse(statusCode, "Invalid request");

                result = new ObjectResult(value) { StatusCode = statusCode };

                return (TOutput)result;
            }

            var request = await req.Body
                                   .ReadAsAsync<DbUserRequest>()
                                   .ConfigureAwait(false);

            try
            {
                var users = this._mapper.Map<List<KorDevAus.Entities.User>>(request.Users);

                var response = await this._service
                                         .UpsertUsersAsync(users)
                                         .MapAsync<KorDevAus.Entities.User, DbUser>(this._mapper)
                                         .BuildResponseAync<DbUserCollectionResponse, DbUser>()
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