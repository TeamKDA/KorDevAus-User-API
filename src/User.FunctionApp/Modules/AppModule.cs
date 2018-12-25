using System.Net.Http;
using System.Reflection;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;

using Microsoft.Extensions.DependencyInjection;

using Module = Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions.Module;

namespace Kda.User.FunctionApp.Modules
{
    /// <summary>
    /// This represents the base module entity for DI. This MUST be inherited.
    /// </summary>
    public abstract class AppModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();

            services.AddSingleton<HttpClient>();

            services.AddAutoMapper(Assembly.GetAssembly(this.GetType()));
        }
    }
}