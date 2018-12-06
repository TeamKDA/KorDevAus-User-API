using System.Net.Http;
using System.Reflection;

using AutoMapper;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Functions;
using Kda.User.FunctionApp.Handlers;

using KorDevAus.Orm;

using MailChimp.Net;
using MailChimp.Net.Interfaces;

using Microsoft.EntityFrameworkCore;
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
            services.AddSingleton<HttpClient>();
            services.AddSingleton<IMailChimpManager, MailChimpManager>(p => new MailChimpManager(p.GetService<AppSettings>().MailChimp.ApiKey));

            services.AddSingleton<IKdaDbContext, KdaDbContext>(p =>
            {
                var builder = new DbContextOptionsBuilder<KdaDbContext>()
                                  .UseSqlServer(p.GetService<AppSettings>().KdaDbConnectionString);
                var context = new KdaDbContext(builder.Options);

                return context;
            });

            services.AddAutoMapper(Assembly.GetAssembly(this.GetType()));

            services.AddTransient<IGetMsalUsersFunction, GetMsalUsersFunction>();
            services.AddTransient<IGetAdalUsersFunction, GetAdalUsersFunction>();
            services.AddTransient<IAddMailChimpUsersFunction, AddMailChimpUsersFunction>();
            services.AddTransient<IGetMailChimpUsersFunction, GetMailChimpUsersFunction>();
            services.AddTransient<IGetMailChimpUserFunction, GetMailChimpUserFunction>();
            services.AddTransient<IGetDbUsersFunction, GetDbUsersFunction>();

            services.AddTransient<IMsalGraphServiceHandler, MsalGraphServiceHandler>();
            services.AddTransient<IAdalGraphServiceHandler, AdalGraphServiceHandler>();
            services.AddTransient<IMailChimpServiceHandler, MailChimpServiceHandler>();
        }
    }
}