using DriversPlatform.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.DAL
{
    public class IdentityDataInitializer
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            SeedRole(roleManager, "admin");
            SeedRole(roleManager, "driver");
            SeedRole(roleManager, "instructor");

            SeedUsers(userManager);
            
        }

        public static void SeedRole(RoleManager<Role> roleManager, string role)
        {
            if (!roleManager.RoleExistsAsync(role).Result)
            {
                var roleObject = new Role();
                roleObject.Name = role;
                IdentityResult roleResult = roleManager.CreateAsync(roleObject).Result;
            }
        }

        public static void SeedUsers (UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new User();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                user.EmailConfirmed = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = userManager.CreateAsync
                (user, "1Admin.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"admin").Wait();
                }

            }
        }
    }
}
