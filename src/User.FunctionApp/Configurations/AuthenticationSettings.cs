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
            this.MsalScopes = new List<string>();
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
        /// Gets or sets the authority URI for authentication.
        /// </summary>
        public virtual string AuthorityUri { get; set; }

        /// <summary>
        /// Gets or sets the base URI for authentication through ADAL.
        /// </summary>
        public virtual string AdalBaseUri { get; set; }

        /// <summary>
        /// Gets or sets the API version for authentication through ADAL.
        /// </summary>
        public virtual string AdalApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the base URI for authentication through MSAL.
        /// </summary>
        public virtual string MsalBaseUri { get; set; }

        /// <summary>
        /// Gets or sets the API version for authentication through MSAL.
        /// </summary>
        public virtual string MsalApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the list of scopes for Graph API.
        /// </summary>
        public virtual List<string> MsalScopes { get; set; }
    }
}
