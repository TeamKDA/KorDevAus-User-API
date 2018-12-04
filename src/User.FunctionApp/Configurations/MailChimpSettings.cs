namespace Kda.User.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the MailChimp settings entity.
    /// </summary>
    public class MailChimpSettings
    {
        /// <summary>
        /// Gets or sets the base URI of the API.
        /// </summary>
        public virtual string BaseUri { get; set; }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        public virtual string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the API key for MailChimp.
        /// </summary>
        public virtual string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the mailing list ID.
        /// </summary>
        public virtual string ListId { get; set; }
    }
}