using System.Collections.Generic;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the base collection response entity. This MUST be inherited.
    /// </summary>
    /// <typeparam name="T">Type of user.</typeparam>
    public abstract class UserCollectionResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbUserCollectionResponse"/> class.
        /// </summary>
        protected UserCollectionResponse()
        {
            this.Users = new List<T>();
        }

        /// <summary>
        /// Gets or sets the list of user instances.
        /// </summary>
        public virtual List<T> Users { get; set; }
    }
}