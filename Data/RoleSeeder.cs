using Microsoft.AspNetCore.Identity;
using NomadBuddy00.Constants;

namespace NomadBuddy00.Data
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())  // 🔥 Create a scope
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(Roles.ADMIN))
                    await roleManager.CreateAsync(new IdentityRole(Roles.ADMIN));

                if (!await roleManager.RoleExistsAsync(Roles.NOMAD))
                    await roleManager.CreateAsync(new IdentityRole(Roles.NOMAD));

                if (!await roleManager.RoleExistsAsync(Roles.BUDDY))
                    await roleManager.CreateAsync(new IdentityRole(Roles.BUDDY));
            }
        }
    }

}
