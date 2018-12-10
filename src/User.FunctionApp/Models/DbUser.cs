using System;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the user on database.
    /// </summary>
    public class DbUser
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public virtual Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the display name on AAD B2C.
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the first name on AAD B2C.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name on AAD B2C.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email on AAD B2C.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the profile image URL.
        /// </summary>
        public virtual string ProfileImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the ID from Azure AD B2C.
        /// </summary>
        public virtual Guid AadId { get; set; }

        /// <summary>
        /// Gets or sets the ID from MailChimp.
        /// </summary>
        public virtual Guid MailChimpId { get; set; }
    }
}