using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Data
{
    public static class ApplicationSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //Create Roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Designer", "Manager", "Admin" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //Create Users
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (userManager.FindByEmailAsync("truongtv0121@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "truongtv0121@gmail.com",
                    Email = "truongtv0121@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }
            if (userManager.FindByEmailAsync("admin1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin1@outlook.com",
                    Email = "admin1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("daltond@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "daltond@gmail.com",
                    Email = "daltond@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Designer").Wait();
                }
            }
            if (userManager.FindByEmailAsync("user1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user1@outlook.com",
                    Email = "user1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;
                //Not in any role
            }
        }
    }
}
