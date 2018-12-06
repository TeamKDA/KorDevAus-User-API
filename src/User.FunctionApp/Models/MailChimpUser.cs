using System;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the user on MailChimp.
    /// </summary>
    public class MailChimpUser
    {
        /// <summary>
        /// Gets or sets the user Id.
        /// </summary>
        public virtual string UserId { get; set; }

        /// <summary>
        /// Gets or sets the mailing list Id.
        /// </summary>
        public virtual string ListId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Korean name.
        /// </summary>
        public virtual string KoreanName { get; set; }

        /// <summary>
        /// Gets or sets the subscription status.
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// Gets or sets the date when the record was last sync'd.
        /// </summary>
        public virtual DateTimeOffset? DateSynced { get; set; }
    }
}