using System;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the group on database.
    /// </summary>
    public class DbGroup
    {
        /// <summary>
        /// Gets or sets the group Id.
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the date when the user has joined.
        /// </summary>
        public virtual DateTimeOffset DateJoined { get; set; }
    }
}