using CadastroDeVeiculos.Business.Interfaces.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeVeiculos.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public void SeedUsers()
        {
            if (this._userManager.FindByEmailAsync("igorEmployee@test").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "igorEmployee@test";
                user.Email = "igorEmployee@test";
                user.NormalizedUserName = "IGOREMPLOYEE@TEST";
                user.NormalizedEmail = "IGOREMPLOYEE@TEST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var paSsword = "@Igor4500";
                IdentityResult result = this._userManager.CreateAsync(user, paSsword).Result;

                if (result.Succeeded)
                {
                    this._userManager.AddToRoleAsync(user, "Employee").Wait();
                }
            }

            if (this._userManager.FindByEmailAsync("adminSystem@test").Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = "adminSystem@test";
                user.Email = "adminSystem@test";
                user.NormalizedUserName = "ADMINSYSTEM@TEST";
                user.NormalizedEmail = "ADMINSYSTEM@TEST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var paSsword = "@Admin4500";
                IdentityResult result = this._userManager.CreateAsync(user, paSsword).Result;

                if (result.Succeeded)
                {
                    this._userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }
        }

        public void SeedRoles()
        {
           if (!this._roleManager.RoleExistsAsync("Employee").Result)
           {
                var role = new IdentityRole();
                role.Name = "Employee";
                role.NormalizedName = "EMPLOYEE";

                IdentityResult roleResult = this._roleManager.CreateAsync(role).Result;
           }

            if (!this._roleManager.RoleExistsAsync("Manager").Result)
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                role.NormalizedName = "MANAGER";

                IdentityResult roleResult = this._roleManager.CreateAsync(role).Result;
            }
        }

    }
}
