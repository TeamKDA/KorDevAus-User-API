using System;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

namespace Kda.User.FunctionApp.Functions.FunctionOptions
{
    /// <summary>
    /// This represents the options entity for the <see cref="GetDbUserFunction"/> class.
    /// </summary>
    public class GetDbUserFunctionOptions : FunctionOptionsBase
    {
        /// <summary>
        /// Gets or sets the user Id from the database.
        /// </summary>
        public Guid UserId { get; set; }
    }
}