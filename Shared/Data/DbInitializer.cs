using Microsoft.AspNetCore.Identity;

namespace Shared.Data;

public static class DbInitializer
{
    public static void SeedUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        SeedRoles(roleManager);
        SeedAdminUser(userManager);
    }

    private static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync("admin").Result)
        {
            var role = new IdentityRole
            {
                Name = "admin"
            };

            _ = roleManager.CreateAsync(role).Result;
        }

        if (!roleManager.RoleExistsAsync("user").Result)
        {
            var role = new IdentityRole
            {
                Name = "user"
            };

            _ = roleManager.CreateAsync(role).Result;
        }
    }

    private static void SeedAdminUser(UserManager<IdentityUser> userManager)
    {
        if (userManager.FindByNameAsync("admin").Result == null)
        {
            var user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin"
            };

            var result = userManager.CreateAsync(user, "Admin#123").Result;

            if (result.Succeeded)
            {
                _ = userManager.AddToRoleAsync(user, "admin").Result;
            }
        }
    }
}