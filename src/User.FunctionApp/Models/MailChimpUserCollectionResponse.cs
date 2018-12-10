namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the response entity for user collection from MailChimp.
    /// </summary>
    public class MailChimpUserCollectionResponse : UserCollectionResponse<MailChimpUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailChimpUserCollectionResponse"/> class.
        /// </summary>
        public MailChimpUserCollectionResponse()
            : base()
        {
        }
    }
}