using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DevAssuncaoCarros.API.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DevAssuncaoCarros.API.Configurations;
using Microsoft.AspNetCore.Authorization;

namespace DevAssuncaoCarros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizaController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JsonConfig _appSettings;

        public AuthorizaController(
                                   UserManager<IdentityUser> userManager,
                                   SignInManager<IdentityUser> signIn, IOptions<JsonConfig> appSettings)
        {
            _userManager = userManager;
            _signInManager = signIn;
            _appSettings = appSettings.Value;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> RegisterUser(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(GerarTokenJWT());
            }

            foreach (var erro in result.Errors)
            {
                BadRequest(erro.Description);
            }

            return Ok(registerUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(GerarTokenJWT());
            }
            if (result.IsLockedOut)
            {
                BadRequest("Usuário temporariamente bloqueado por tentativas inválidas");
            }

            BadRequest("Usuário ou senha incorretos");
            return BadRequest(loginUser);
        }


        private string GerarTokenJWT()
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expiracao),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
    }
}

