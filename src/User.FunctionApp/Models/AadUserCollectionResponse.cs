namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the response entity for user collection from Azure AD B2C.
    /// </summary>
    public class AadUserCollectionResponse : UserCollectionResponse<AadUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AadUserCollectionResponse"/> class.
        /// </summary>
        public AadUserCollectionResponse()
            : base()
        {
        }
    }
}