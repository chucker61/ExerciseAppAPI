using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminName = "Admin";
            const string adminPassword = "Asdddd123*";

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var user = await userManager.FindByNameAsync(adminName);
            if (user is null)
            {
                user = new AppUser()
                {
                    UserName = adminName,
                    Email = "meliksahmertcakir@hotmail.com",
                    PhoneNumber = "05516208340"
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception("Admin could not created");

                var roles = roleManager.Roles.Select(r => r.Name).ToList();
                var roleResult = await userManager.AddToRolesAsync(user, roles);
                if (!roleResult.Succeeded)
                    throw new Exception("Roles could not found.");
            }
        }
    }
}
