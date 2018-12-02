using Aliencube.AzureFunctions.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;

namespace Kda.User.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity.
    /// </summary>
    public class AppSettings
    {
        private const string AuthPropertyKey = "Auth";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
        {
            var config = new ConfigurationBuilder()
                             .AddEnvironmentVariables()
                             .Build();

            this.Auth = config.Get<AuthenticationSettings>(AuthPropertyKey);
        }

        /// <summary>
        /// Gets the <see cref="AuthenticationSettings"/> instance.
        /// </summary>
        public virtual AuthenticationSettings Auth { get; }
    }
}