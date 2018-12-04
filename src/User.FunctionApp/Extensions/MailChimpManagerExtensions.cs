using System.Threading.Tasks;

using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

namespace Kda.User.FunctionApp.Extensions
{
    public static class MailChimpManagerExtensions
    {
        public static async Task<Member> CreateMemberIfNotExistsAsync(this IMemberLogic logic, string listId, Member member)
        {
            var result = await logic.AddOrUpdateAsync(listId, member).ConfigureAwait(false);

            return result;
        }
    }
}