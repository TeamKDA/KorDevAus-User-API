using System;
using System.Linq;

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
            this.CreateMap<AdalUser, AadUser>()
                .ForMember(d => d.UserId, o => o.MapFrom(s => Guid.Parse(s.ObjectId)))
                .ForMember(d => d.Upn, o => o.MapFrom(s => s.UserPrincipalName))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.DisplayName))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.GivenName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.Surname))
                .ForMember(d => d.Email, o => o.MapFrom(s => GetEmail(s)))
                .ForMember(d => d.DateJoined, o => o.MapFrom(s => s.CreatedDateTime))
                ;
        }

        private static string GetEmail(AdalUser user)
        {
            var email = user.OtherMails.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(email))
            {
                return email;
            }

            var tvp = user.SignInNames.FirstOrDefault(p => p.Type.Equals("emailAddress", StringComparison.CurrentCultureIgnoreCase));
            if (tvp == null)
            {
                return null;
            }

            return (string)tvp.Value;
        }
    }
}