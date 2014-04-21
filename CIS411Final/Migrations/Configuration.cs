using CIS411Final.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CIS411Final.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CIS411Final.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CIS411Final.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "btroncone") || !context.Users.Any(u => u.UserName == "ablazin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {UserName = "btroncone"};
                var user2 = new ApplicationUser { UserName = "ablazin" };

                manager.Create(user, "password");
                manager.Create(user2, "password");

            }

        }
    }
}
