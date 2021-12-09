using AUTOBEM.Application.Extensions;
using AUTOBEM.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AUTOBEM.Application.Controllers
{
    [Route("api/v1/account")]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] UserModel model)
        {
            UserModel user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            string token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo()
        {
            return "Anônimo";
        }

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado()
        {
            return string.Format("Autenticado - {0}", User.Identity.Name);
        }

        [HttpGet]
        [Route("empregado")]
        [Authorize(Roles = "empregado,gerente")]
        public string Empregado()
        {
            return "Funcionário";
        }

        [HttpGet]
        [Route("gerente")]
        [Authorize(Roles = "gerente")]
        public string Gerente()
        {
            return "Gerente" ?? "Só para Gerentes";
        }
    }
}
