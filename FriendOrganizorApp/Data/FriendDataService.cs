using FriendOrganizor.DataAccess;
using FriendOrganizor.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FriendOrganizorApp.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizorDbContext> _dbContext;

        public FriendDataService(Func<FriendOrganizorDbContext> dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<List<Friend>> GetAllAsync()
        {
            using (var ctx =_dbContext())
            {
              return await ctx.Friends.AsNoTracking().ToListAsync();
  
            }
        }
    }
}
