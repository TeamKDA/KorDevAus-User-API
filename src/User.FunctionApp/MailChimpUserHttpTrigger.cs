using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection;
using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Kda.User.FunctionApp.Functions;
using Kda.User.FunctionApp.Modules;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using ErrorResponse = Kda.User.FunctionApp.Models.ErrorResponse;

namespace Kda.User.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for MailChimp users.
    /// </summary>
    public static partial class MailChimpUserHttpTrigger
    {
        /// <summary>
        /// Gets the <see cref="IFunctionFactory"/> instance.
        /// </summary>
        public static IFunctionFactory Factory = new FunctionFactory<AppModule>();

        /// <summary>
        /// Invokes the function endpoint to get the list of users from MailChimp.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the <see cref="IActionResult"/> containing the list of AAD B2C users.</returns>
        [FunctionName(nameof(GetMailChimpUsers))]
        public static async Task<IActionResult> GetMailChimpUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "mailchimp/users")] HttpRequest req,
            ILogger log)
        {
            IActionResult result;
            try
            {
                result = await Factory.Create<IAddMailChimpUsersFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req)
                                      .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var value = new ErrorResponse(statusCode, ex.Message);

                result = new ObjectResult(value) { StatusCode = statusCode };
            }

            return result;
        }

        /// <summary>
        /// Invokes the function endpoint to get the user from MailChimp.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="email">E-mail address.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the <see cref="IActionResult"/> containing the list of AAD B2C users.</returns>
        [FunctionName(nameof(GetMailChimpUser))]
        public static async Task<IActionResult> GetMailChimpUser(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "mailchimp/users/{email}")] HttpRequest req,
            string email,
            ILogger log)
        {
            IActionResult result;
            try
            {
                result = await Factory.Create<IAddMailChimpUsersFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req)
                                      .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var value = new ErrorResponse(statusCode, ex.Message);

                result = new ObjectResult(value) { StatusCode = statusCode };
            }

            return result;
        }

        /// <summary>
        /// Invokes the function endpoint to add the list of users to MailChimp.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the <see cref="IActionResult"/> containing the list of AAD B2C users.</returns>
        [FunctionName(nameof(AddMailChimpUsers))]
        public static async Task<IActionResult> AddMailChimpUsers(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "mailchimp/users")] HttpRequest req,
            ILogger log)
        {
            IActionResult result;
            try
            {
                result = await Factory.Create<IAddMailChimpUsersFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req)
                                      .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var value = new ErrorResponse(statusCode, ex.Message);

                result = new ObjectResult(value) { StatusCode = statusCode };
            }

            return result;
        }
    }
}