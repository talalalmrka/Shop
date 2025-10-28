using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Shop.Data
{
    public static class UsersRolesSeeder
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // --- Create Roles if they don't exist ---
            string[] roles = { "Admin", "Customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // --- Create Admin User ---
            var adminEmail = "16ftim@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Admin123!"); // كلمة مرور قوية
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // --- Create Customer User ---
            var customerEmail = "customer@shop.com";
            var customerUser = await userManager.FindByEmailAsync(customerEmail);
            if (customerUser == null)
            {
                customerUser = new IdentityUser
                {
                    UserName = customerEmail,
                    Email = customerEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(customerUser, "Customer123!"); // كلمة مرور قوية
                await userManager.AddToRoleAsync(customerUser, "Customer");
            }
        }
    }
}
