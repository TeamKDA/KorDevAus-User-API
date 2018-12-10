namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the base response entity. This MUST be inherited.
    /// </summary>
    /// <typeparam name="T">Type of user.</typeparam>
    public abstract class UserResponse<T>
    {
        /// <summary>
        /// Gets or sets the user instance.
        /// </summary>
        public virtual T User { get; set; }
    }
}