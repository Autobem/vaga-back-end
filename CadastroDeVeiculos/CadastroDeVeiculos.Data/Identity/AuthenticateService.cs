using CadastroDeVeiculos.Business.Interfaces.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await this._signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                await this._signInManager.SignInAsync(applicationUser, isPersistent: true);
            }

            return result.Succeeded;

        }

        public async  Task Logout()
        {
            await this._signInManager.SignOutAsync();
        }
    }
}
