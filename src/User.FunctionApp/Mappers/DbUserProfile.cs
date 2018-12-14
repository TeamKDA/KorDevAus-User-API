using System.Linq;

using AutoMapper;

using Kda.User.FunctionApp.Models;

namespace Kda.User.FunctionApp.Mappers
{
    /// <summary>
    /// This represents the mapping profile entity between <see cref="Microsoft.Graph.User"/> and <see cref="AadUser"/>.
    /// </summary>
    public class DbUserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbUserProfile"/> class.
        /// </summary>
        public DbUserProfile()
        {
            this.CreateMap<KorDevAus.Entities.User, DbUser>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.DisplayName))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.AadId, o => o.MapFrom(s => s.ActiveDirectoryId))
                .ForMember(d => d.ProfileImageUrl, o => o.MapFrom(s => s.ProfileImageUrl))
                .ForMember(d => d.MailChimpId, o => o.MapFrom(s => s.MailChimpId))
                .ForMember(d => d.Groups, o => o.MapFrom(s => s.GroupUsers))
                //.ForMember(d => d.Groups, o => o.MapFrom(s => s.GroupUsers.Select(q => q.Group)))
                ;
        }
    }
}