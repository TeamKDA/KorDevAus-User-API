using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Models;

using KorDevAus.Orm;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get users from MailChimp.
    /// </summary>
    public class GetDbUsersFunction : FunctionBase<ILogger>, IGetDbUsersFunction
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IKdaDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMailChimpUsersFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="context"><see cref="IKdaDbContext"/> instance.</param>
        public GetDbUsersFunction(AppSettings settings, IMapper mapper, IKdaDbContext context)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var result = (IActionResult)null;
            try
            {
                var users = await this._context.Users
                                      .ToListAsync()
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