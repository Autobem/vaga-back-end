
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Business.Interfaces.Account;
using CadastroDeVeiculos.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            this._authenticate = authenticate;
            this._configuration = configuration;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] LoginDTO loginDTO)
        {
            var register = await this._authenticate.RegisterUser(loginDTO.Email, loginDTO.Password);

            if (register)
            {
                return Ok($"{loginDTO.Email} was create successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }


        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await this._authenticate.Authenticate(loginDTO.Email, loginDTO.Password);

            if (result)
            {
                return GenerateToken(loginDTO);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerateToken(LoginDTO loginDTO)
        {
            var claims = new[]
            {
                new Claim("email", loginDTO.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var credencials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: this._configuration["Jwt:Issuer"],
                audience: this._configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credencials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
