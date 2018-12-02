namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the response entity for user from Azure AD B2C.
    /// </summary>
    public class AadUserResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="AadUser"/> instance.
        /// </summary>
        public virtual AadUser User { get; set; }
    }
}