using System.Threading.Tasks;

using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="MailChimpManager"/> class.
    /// </summary>
    public static class MailChimpManagerExtensions
    {
        /// <summary>
        /// Creates or updates a member onto MailChimp.
        /// </summary>
        /// <param name="logic"><see cref="IMemberLogic"/> instance.</param>
        /// <param name="listId">MailChimp list Id.</param>
        /// <param name="member"><see cref="Member"/> instance.</param>
        /// <returns><see cref="Member"/> instance created or updated.</returns>
        public static async Task<Member> CreateMemberIfNotExistsAsync(this IMemberLogic logic, string listId, Member member)
        {
            var result = await logic.AddOrUpdateAsync(listId, member).ConfigureAwait(false);

            return result;
        }
    }
}