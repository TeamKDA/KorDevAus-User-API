using System.Collections.Generic;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the request entity for MailChimp users.
    /// </summary>
    public class MailChimpUserRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailChimpUserRequest"/> class.
        /// </summary>
        public MailChimpUserRequest()
        {
            this.Users = new List<MailChimpUser>();
        }

        /// <summary>
        /// Gets or sets the list of <see cref="MailChimpUser"/> instances.
        /// </summary>
        public virtual List<MailChimpUser> Users { get; set; }
    }
}