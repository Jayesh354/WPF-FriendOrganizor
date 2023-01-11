using FriendOrganizor.DataAccess;
using FriendOrganizor.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizorApp.Data
{
    public class LookupDataService : ILookupDataService
    {
        private Func<FriendOrganizorDbContext> _contexCreator;

        public LookupDataService(Func<FriendOrganizorDbContext> contexCreator)
        {
            _contexCreator = contexCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            using (var ctx = _contexCreator())
            {
                return await ctx.Friends.AsNoTracking()
                    .Select(friend => new LookupItem
                    {
                        Id = friend.Id,
                        DisplayMember = friend.FirstName +" "+ friend.LastName
                    }).ToListAsync();

            }
        }
    }
}
