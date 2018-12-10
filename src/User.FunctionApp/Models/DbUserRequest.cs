using System.Collections.Generic;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the request entity for database users.
    /// </summary>
    public class DbUserRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbUserRequest"/> class.
        /// </summary>
        public DbUserRequest()
        {
            this.Users = new List<DbUser>();
        }

        /// <summary>
        /// Gets or sets the list of <see cref="DbUser"/> instances.
        /// </summary>
        public virtual List<DbUser> Users { get; set; }
    }
}