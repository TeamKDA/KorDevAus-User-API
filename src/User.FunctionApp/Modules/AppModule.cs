﻿using System.Reflection;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Functions;
using Kda.User.FunctionApp.Handlers;
using Microsoft.Extensions.DependencyInjection;

using Module = Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions.Module;

namespace Kda.User.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for DI.
    /// </summary>
    public class AppModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();

            services.AddAutoMapper(Assembly.GetAssembly(this.GetType()));

            services.AddTransient<IGetAadUsersFunction, GetAadUsersFunction>();
            services.AddTransient<IGraphServiceHandler, GraphServiceHandler>();
        }
    }
}