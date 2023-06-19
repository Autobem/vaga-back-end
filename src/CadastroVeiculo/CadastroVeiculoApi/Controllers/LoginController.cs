using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CadastroVeiculoApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration Configuration)
        {
            _config = Configuration;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioDto loginDetalhes)
        {
            bool resultado = ValidarUsuario(loginDetalhes);
            if (resultado)
            {
                var tokenString = GerarTokenJWT();
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }


        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,expires: expiry, signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        private bool ValidarUsuario(UsuarioDto loginDetalhes)
        {
            if (loginDetalhes.NomeUsuario == "VagaAutoBem" && loginDetalhes.Senha == "AutoBemCaminhoes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
