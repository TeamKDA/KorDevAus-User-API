using System.Collections.Generic;

namespace Kda.User.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the authentication settings entity from app settings.
    /// </summary>
    public class AuthenticationSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationSettings"/> class.
        /// </summary>
        public AuthenticationSettings()
        {
            this.Scopes = new List<string>();
        }

        /// <summary>
        /// Gets or sets the tenant Id.
        /// </summary>
        public virtual string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the client Id (or application Id).
        /// </summary>
        public virtual string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public virtual string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        public virtual string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the base URI for authentication.
        /// </summary>
        public virtual string BaseUri { get; set; }

        /// <summary>
        /// Gets or sets the API version for authentication.
        /// </summary>
        public virtual string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the URI for Graph API.
        /// </summary>
        public virtual string GraphUri { get; set; }

        /// <summary>
        /// Gets or sets the list of scopes for Graph API.
        /// </summary>
        public virtual List<string> Scopes { get; set; }
    }
}
