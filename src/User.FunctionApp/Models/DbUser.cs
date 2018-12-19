using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the user on database.
    /// </summary>
    public class DbUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbUser"/> class.
        /// </summary>
        public DbUser()
        {
            this.Groups = new List<DbGroup>();
        }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public virtual Guid Id { get; set; }

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
        public virtual string MailChimpId { get; set; }

        /// <summary>
        /// Gets or sets the date when the user has joined.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTimeOffset? DateJoined { get; set; }

        /// <summary>
        /// Gets or sets the list of groups.
        /// </summary>
        public virtual List<DbGroup> Groups { get; set; }
    }
}