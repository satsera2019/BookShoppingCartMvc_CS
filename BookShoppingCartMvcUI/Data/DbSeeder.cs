using BookShoppingCartMvcUI.Constants;
using Microsoft.AspNetCore.Identity;

namespace BookShoppingCartMvcUI.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            // adding some roles to db
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // create admin user
            var admin = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true,
            };

            var userInDb = await userManager.FindByEmailAsync(admin.Email);
            if (userInDb is null) 
            {
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());

            }
        }
    }
}
