﻿using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.Logging;

namespace Kda.User.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="GetAadUsersFunction"/> class.
    /// </summary>
    public interface IGetAadUsersFunction : IFunction<ILogger>
    {
    }
}