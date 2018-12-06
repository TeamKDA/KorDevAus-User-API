using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Extensions;
using Kda.User.FunctionApp.Functions.FunctionOptions;
using Kda.User.FunctionApp.Handlers;
using Kda.User.FunctionApp.Models;

using MailChimp.Net.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get user from MailChimp.
    /// </summary>
    public class GetMailChimpUserFunction : FunctionBase<ILogger>, IGetMailChimpUserFunction
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IMailChimpServiceHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMailChimpUserFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="handler"><see cref="IMailChimpServiceHandler"/> instance.</param>
        public GetMailChimpUserFunction(AppSettings settings, IMapper mapper, IMailChimpServiceHandler handler)
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

            var opt = options as GetMailChimpUserFunctionOptions;
            if (opt == null)
            {
                var statusCode = (int)HttpStatusCode.BadRequest;
                var value = new ErrorResponse(statusCode, "Invalid request");

                result = new ObjectResult(value) { StatusCode = statusCode };

                return (TOutput)result;
            }

            try
            {
                var user = await this._handler
                                     .Build()
                                     .GetUserAsync<Member>(opt.UserId)
                                     .MapAsync<Member, MailChimpUser>(this._mapper)
                                     .ConfigureAwait(false);

                result = new OkObjectResult(user);
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