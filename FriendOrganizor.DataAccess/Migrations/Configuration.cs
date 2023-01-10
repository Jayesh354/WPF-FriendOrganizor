namespace FriendOrganizor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizor.DataAccess.FriendOrganizorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizor.DataAccess.FriendOrganizorDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Friends.AddOrUpdate(f=>f.FirstName,
                new Model.Friend {FirstName="Gopal",LastName="Das" },
                new Model.Friend {FirstName="Mohan",LastName="Gandhi", },
                new Model.Friend {FirstName="Kanji",LastName="Pathak" });
        }
    }
}
