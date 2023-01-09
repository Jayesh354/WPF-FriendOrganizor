using FriendOrganizor.Model;
using System.Collections.Generic;

namespace FriendOrganizorApp.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Gopal", LastName = "Das" };
            yield return new Friend { FirstName = "Mohan", LastName = "Das" };
            yield return new Friend { FirstName = "Ranchod", LastName = "Das" };
        }
    }
}
