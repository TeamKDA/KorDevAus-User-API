namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the response entity for user collection from database.
    /// </summary>
    public class DbUserCollectionResponse : UserCollectionResponse<DbUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbUserCollectionResponse"/> class.
        /// </summary>
        public DbUserCollectionResponse()
            : base()
        {
        }
    }
}