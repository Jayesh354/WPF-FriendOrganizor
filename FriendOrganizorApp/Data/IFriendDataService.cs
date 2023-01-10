using FriendOrganizor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizorApp.Data
{
    public interface IFriendDataService
    {
        Task<List<Friend>> GetAllAsync();
    }
}