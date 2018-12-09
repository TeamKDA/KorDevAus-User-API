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
    /// This represents the HTTP trigger entity for AAD B2C users.
    /// </summary>
    public static class AadUserHttpTrigger
    {
        /// <summary>
        /// Gets the <see cref="IFunctionFactory"/> instance.
        /// </summary>
        public static IFunctionFactory Factory = new FunctionFactory<AadModule>();

        /// <summary>
        /// Invokes the function endpoint to get the list of users through MSAL.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the <see cref="IActionResult"/> containing the list of AAD B2C users.</returns>
        [FunctionName(nameof(GetMsalUsers))]
        public static async Task<IActionResult> GetMsalUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "msal/users")] HttpRequest req,
            ILogger log)
        {
            IActionResult result;
            try
            {
                result = await Factory.Create<IGetMsalUsersFunction, ILogger>(log)
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
        /// Invokes the function endpoint to get the list of users through ADAL.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the <see cref="IActionResult"/> containing the list of AAD B2C users.</returns>
        [FunctionName(nameof(GetAdalUsers))]
        public static async Task<IActionResult> GetAdalUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "adal/users")] HttpRequest req,
            ILogger log)
        {
            IActionResult result;
            try
            {
                result = await Factory.Create<IGetAdalUsersFunction, ILogger>(log)
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