using AutoMapper;

using Kda.User.FunctionApp.Models;

namespace Kda.User.FunctionApp.Mappers
{
    /// <summary>
    /// This represents the mapping profile entity between <see cref="Microsoft.Graph.User"/> and <see cref="AadUser"/>.
    /// </summary>
    public class AadUserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AadUserProfile"/> class.
        /// </summary>
        public AadUserProfile()
        {
        }
    }
}