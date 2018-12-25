using Kda.User.FunctionApp.Functions;

using Microsoft.Extensions.DependencyInjection;

namespace Kda.User.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for DI.
    /// </summary>
    public class SwaggerModule : AppModule
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            base.Load(services);

            services.AddTransient<IRenderSwaggerFunction, RenderSwaggerFunction>();
        }
    }
}