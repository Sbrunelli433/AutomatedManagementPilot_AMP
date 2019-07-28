using AutomatedManagementPilot_AMP.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //context.Database.EnsureCreated();
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Supervisor", "Manager", "Employee" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    var context = serviceProvider.GetService<ApplicationDbContext>();
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //    string[] roles = new string[] { "Admin","Supervisor", "Manager", "Employee" };

        //    foreach (string role in roles)
        //    {
        //        var roleStore = new RoleStore<IdentityRole>(context);

        //        if (!context.Roles.Any(r => r.Name == role))
        //        {
        //            roleStore.CreateAsync(new IdentityRole(role));
        //        }
        //    }
        //    var user = new ApplicationUser
        //    {
        //        Name = "Admin",
        //        Email = "admin@admin.com",
        //        NormalizedEmail = "XXXX@EXAMPLE.COM",
        //        UserName = "Admin",
        //        NormalizedUserName = "ADMIN",
        //        //PhoneNumber = "+111111111111",
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true,
        //        SecurityStamp = Guid.NewGuid().ToString("D")
        //    };


        //    if (!context.Users.Any(u => u.UserName == user.UserName))
        //    {
        //        var password = new PasswordHasher<ApplicationUser>();
        //        var hashed = password.HashPassword(user, "secret");
        //        user.PasswordHash = hashed;

        //        var userStore = new UserStore<ApplicationUser>(context);
        //        var result = userStore.CreateAsync(user);

        //    }

        //    AssignRoles(serviceProvider, user.Email, roles);

        //    context.SaveChangesAsync();
        //}

        //public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        //{
        //    UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
        //    ApplicationUser user = await _userManager.FindByEmailAsync(email);
        //    var result = await _userManager.AddToRolesAsync(user, roles);

        //    return result;
        //}
    }

}

