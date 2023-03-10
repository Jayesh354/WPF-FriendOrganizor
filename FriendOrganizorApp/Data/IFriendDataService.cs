using FriendOrganizor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizorApp.Data
{
    public interface IFriendDataService
    {
        Task<Friend> GetByIdAsync(int friendId);
        Task SaveAsync(Friend friend);
    }
}