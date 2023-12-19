﻿using DataAccess;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Phone_Seller_AspNetCore6.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void ConfigureLocalization(this WebApplication web)
        {
            web.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("en-US")
                .AddSupportedCultures("en-US")
                .SetDefaultCulture("en-US");
            });
        }
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin";

            //UserManager
            UserManager<CustomUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<CustomUser>>();
            //RoleManager
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            CustomUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new CustomUser()
                {
                    Email = "berkaykocak1707@gmail.com",
                    PhoneNumber = "1234567890",
                    UserName = adminUser,
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created.");
                }

                var roleResult = await userManager.AddToRolesAsync(user,
                        roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList()
                    );
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Roller atanamadı.");
                }
            }
        }
    }
}
