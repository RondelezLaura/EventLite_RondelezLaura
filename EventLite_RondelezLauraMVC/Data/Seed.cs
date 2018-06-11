using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventLite_RondelezLauraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLite_RondelezLauraMVC.Data
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" }; IdentityResult roleResult;
            foreach (var roleName in roleNames) {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist) {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
