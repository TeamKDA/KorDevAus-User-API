using System.Collections.Generic;

using AutoMapper;

using Kda.User.FunctionApp.Extensions;
using Kda.User.FunctionApp.Models;

using MailChimp.Net.Models;

namespace Kda.User.FunctionApp.Mappers
{
    /// <summary>
    /// This represents the mapping profile entity between <see cref="Member"/> and <see cref="MailChimpUser"/>.
    /// </summary>
    public class MailChimpUserProfile : Profile
    {
        private const string FirstName = "FNAME";
        private const string LastName = "LNAME";
        private const string KoreanName = "KNAME";

        /// <summary>
        /// Initializes a new instance of the <see cref="AadUserProfile"/> class.
        /// </summary>
        public MailChimpUserProfile()
        {
            this.CreateMap<Member, MailChimpUser>()
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ListId, o => o.MapFrom(s => s.ListId))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.EmailAddress))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => GetMergeField(s, FirstName)))
                .ForMember(d => d.LastName, o => o.MapFrom(s => GetMergeField(s, LastName)))
                .ForMember(d => d.KoreanName, o => o.MapFrom(s => GetMergeField(s, KoreanName)))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.DateSynced, o => o.MapFrom(s => s.LastChanged.ToDateTimeOffset()))
                ;

            this.CreateMap<MailChimpUser, Member>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.EmailAddress, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.MergeFields, o => o.MapFrom(s => SetMergeFields(s)))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                ;
        }

        private static string GetMergeField(Member user, string key)
        {
            var value = user.MergeFields[key] as string;

            return value;
        }

        private static Dictionary<string, object> SetMergeFields(MailChimpUser user)
        {
            var value = new Dictionary<string, object>
                            {
                                { FirstName, user.FirstName },
                                { LastName, user.LastName },
                                { KoreanName, user.KoreanName }
                            };

            return value;
        }
    }
}