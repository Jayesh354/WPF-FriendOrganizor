using FriendOrganizor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizorApp.Data
{
    public interface ILookupDataService
    {
        Task<IEnumerable<LookupItem>> GetFriendLookupAsync();
    }
}