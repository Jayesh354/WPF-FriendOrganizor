using FriendOrganizor.Model;
using System.Collections.Generic;

namespace FriendOrganizorApp.Data
{
    public interface IFriendDataService
    {
        IEnumerable<Friend> GetAll();
    }
}