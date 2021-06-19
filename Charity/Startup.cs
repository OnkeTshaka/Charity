using Charity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Charity.Startup))]
namespace Charity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        // In this method we will create default User roles and Admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";
                user.UserType = "Admin";

                string userPWD = "Password@12";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }


            }
            // creating Creating Customer role 
            if (!roleManager.RoleExists("Donor"))
            {
                var role = new IdentityRole();
                role.Name = "Donor";
                roleManager.Create(role);
                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "Donor";
                user.Email = "admin@gmail.com";
                user.UserType = "Donor";

                string userPWD = "Password@12";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result2 = UserManager.AddToRole(user.Id, "Donor");

                }
            }


            if (!roleManager.RoleExists("Organisation Representative"))
            {
                var role = new IdentityRole();
                role.Name = "OrganisationRep";
                roleManager.Create(role);
                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "OrgainsationRep";
                user.Email = "admin@gmail.com";
                user.UserType = "OrgainsationRep";

                string userPWD = "Password@12";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result3 = UserManager.AddToRole(user.Id, "OrganisationRep");

                }
            }
        }
    }
}

