using System.Net.Http;

using Kda.User.FunctionApp.Functions;
using Kda.User.FunctionApp.Handlers;

using Microsoft.Extensions.DependencyInjection;

namespace Kda.User.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for DI.
    /// </summary>
    public class AadModule : AppModule
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            base.Load(services);

            services.AddTransient<IGetMsalUsersFunction, GetMsalUsersFunction>();
            services.AddTransient<IGetAdalUsersFunction, GetAdalUsersFunction>();
            services.AddTransient<IGetAdalUsersDeltaFunction, GetAdalUsersDeltaFunction>();

            services.AddTransient<IMsalGraphServiceHandler, MsalGraphServiceHandler>();
            services.AddTransient<IAdalGraphServiceHandler, AdalGraphServiceHandler>();
        }
    }
}