using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace BlazorWithPostgresDemo.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin")); 
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            
        }
        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default Us
            var defaultUser = new IdentityUser() 
            { 
                UserName = "dyako", 
                Email = "dyako.baram@gmail.com",
                EmailConfirmed = true, 
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if(user==null)
                {
                    await userManager.CreateAsync(defaultUser, "Assall01!");
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }
            }
        }
    }
}