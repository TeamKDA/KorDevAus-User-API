using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Functions;
using Kda.User.FunctionApp.Services;

using KorDevAus.Orm;
using KorDevAus.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kda.User.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for DI.
    /// </summary>
    public class DbModule : AppModule
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            base.Load(services);

            services.AddSingleton<AppSettings>();

            services.AddTransient<IKdaDbContext, KdaDbContext>(p =>
            {
                var builder = new DbContextOptionsBuilder<KdaDbContext>()
                                  .UseSqlServer(p.GetService<AppSettings>().KdaDbConnectionString);
                var context = new KdaDbContext(builder.Options);

                return context;
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IGroupUserRepository, GroupUserRepository>();

            services.AddTransient<IDbUserService, DbUserService>();

            services.AddTransient<IGetDbUsersFunction, GetDbUsersFunction>();
            services.AddTransient<IGetDbUserFunction, GetDbUserFunction>();
            services.AddTransient<IAddDbUsersFunction, AddDbUsersFunction>();
        }
    }
}