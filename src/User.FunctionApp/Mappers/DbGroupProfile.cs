using AutoMapper;

using Kda.User.FunctionApp.Models;

namespace Kda.User.FunctionApp.Mappers
{
    /// <summary>
    /// This represents the mapping profile entity between <see cref="Microsoft.Graph.User"/> and <see cref="AadUser"/>.
    /// </summary>
    public class DbGroupProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbGroupProfile"/> class.
        /// </summary>
        public DbGroupProfile()
        {
            this.CreateMap<KorDevAus.Entities.Group, DbGroup>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                ;

            this.CreateMap<KorDevAus.Entities.GroupUser, DbGroup>()
                .ForMember(d => d.DateJoined, o => o.MapFrom(s => s.DateJoined))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Group.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Group.Name))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Group.Description))
                ;
       }
    }
}