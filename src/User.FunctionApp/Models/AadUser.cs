using System;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the user on AAD B2C.
    /// </summary>
    public class AadUser
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public virtual Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user principal name (UPN).
        /// </summary>
        public virtual string Upn { get; set; }

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
        /// Gets or sets the date when the record was created on Azure AD B2C.
        /// </summary>
        public virtual DateTimeOffset DateJoined { get; set; }
    }
}