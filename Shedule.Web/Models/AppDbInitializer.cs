using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shedule.Web.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole()
            {
                Name = "admin",
            };

            var userRole = new IdentityRole()
            {
                Name = "user",
            };

            roleManager.Create(adminRole);
            roleManager.Create(userRole);

            var admin = new ApplicationUser()
            {
                Email = "admin@mail.com",
                UserName = "Administrator",
            };

            var password = "Avl371g02pv#";

            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }

            base.Seed(context);
        }
    }
}