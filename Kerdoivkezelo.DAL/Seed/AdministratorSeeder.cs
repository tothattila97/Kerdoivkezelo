﻿using Kerdoivkezelo.DAL.Entities;
using Kerdoivkezelo.DAL.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Seed
{
    public class AdministratorSeeder
    {
        public AdministratorSeeder(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole<int>> RoleManager { get; }
        public async Task Seed()
        {
            if (!await RoleManager.RoleExistsAsync(Roles.Administrators))
                await RoleManager.CreateAsync(new IdentityRole<int> { Name = Roles.Administrators });
            if (!(await UserManager.GetUsersInRoleAsync(Roles.Administrators)).Any())
            {
                var user = new User { Email = "admin@bookshop.hu", Name = "Adminisztrátor", SecurityStamp = Guid.NewGuid().ToString(), UserName = "admin" };
                var createResult = await UserManager.CreateAsync(user, "$Administrator123");
                var addToRoleResult = await UserManager.AddToRoleAsync(user, Roles.Administrators);
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException($"Administrator could not be created: {string.Join(", ", createResult.Errors.Concat(addToRoleResult.Errors).Select(e => e.Description))}");
            }
        }
    }

}

