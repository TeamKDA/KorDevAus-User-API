using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Functions;
using Kda.User.FunctionApp.Handlers;

using MailChimp.Net;
using MailChimp.Net.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Kda.User.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for DI.
    /// </summary>
    public class MailChimpModule : AppModule
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            base.Load(services);

            services.AddSingleton<IMailChimpManager, MailChimpManager>(p => new MailChimpManager(p.GetService<AppSettings>().MailChimp.ApiKey));

            services.AddTransient<IAddMailChimpUsersFunction, AddMailChimpUsersFunction>();
            services.AddTransient<IGetMailChimpUsersFunction, GetMailChimpUsersFunction>();
            services.AddTransient<IGetMailChimpUserFunction, GetMailChimpUserFunction>();

            services.AddTransient<IMailChimpServiceHandler, MailChimpServiceHandler>();
        }
    }
}