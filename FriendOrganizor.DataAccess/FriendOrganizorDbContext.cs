using FriendOrganizor.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizor.DataAccess
{
    public class FriendOrganizorDbContext : DbContext
    {
        public FriendOrganizorDbContext():base("FriendOrganizorDb") 
        { 

        }
        public DbSet<Friend> Friends { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
          
        }
    }
}
