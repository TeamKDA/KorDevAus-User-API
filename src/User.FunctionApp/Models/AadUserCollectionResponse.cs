using System.Collections.Generic;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the response entity for user collection from Azure AD B2C.
    /// </summary>
    public class AadUserCollectionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AadUserCollectionResponse"/> class.
        /// </summary>
        public AadUserCollectionResponse()
        {
            this.Users = new List<AadUser>();
        }

        /// <summary>
        /// Gets or sets the list of <see cref="AadUser"/> instances.
        /// </summary>
        public virtual List<AadUser> Users { get; set; }
    }
}