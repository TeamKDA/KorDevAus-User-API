namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the entity for type/value pair.
    /// </summary>
    public class TypeValuePair
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public virtual object Value { get; set; }
    }
}