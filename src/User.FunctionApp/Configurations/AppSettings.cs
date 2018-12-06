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
        private const string MailChimpPropertyKey = "MailChimp";
        private const string KdaDbConnectionKey = "KorDevAus";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
        {
            var config = new ConfigurationBuilder()
                             .AddEnvironmentVariables()
                             .Build();

            this.Auth = config.Get<AuthenticationSettings>(AuthPropertyKey);
            this.MailChimp = config.Get<MailChimpSettings>(MailChimpPropertyKey);
            this.KdaDbConnectionString = config.GetConnectionString(KdaDbConnectionKey);
        }

        /// <summary>
        /// Gets the <see cref="AuthenticationSettings"/> instance.
        /// </summary>
        public virtual AuthenticationSettings Auth { get; }

        /// <summary>
        /// Gets the <see cref="MailChimpSettings"/> instance.
        /// </summary>
        public virtual MailChimpSettings MailChimp { get; }

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        public virtual string KdaDbConnectionString { get; }
    }
}