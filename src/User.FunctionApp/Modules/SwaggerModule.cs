using System.Net.Http;

using Kda.User.FunctionApp.Functions;

using Microsoft.Extensions.DependencyInjection;

using Module = Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions.Module;

namespace Kda.User.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for DI.
    /// </summary>
    public class SwaggerModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            base.Load(services);

            services.AddSingleton<HttpClient>();

            services.AddTransient<IRenderSwaggerFunction, RenderSwaggerFunction>();
        }
    }
}