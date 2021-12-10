using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Usuarios;
using Projeto.Presentation.Api.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributo
        private readonly IUsuarioApplicationService usuarioApplicationService;
        private readonly TokenService tokenService;

        public LoginController(IUsuarioApplicationService usuarioApplicationService, TokenService tokenService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post(UsuarioAutenticacaoModel model)
        {
            try
            {
                var usuario = usuarioApplicationService.GetByEmailAndSenha(model);

                if (usuario != null)
                {
                    var token = tokenService.GenerateToken(model.Email);
                    return Ok(token);
                }
                else
                {
                    return StatusCode(403, "Usuário não encontrado. Acesso Negado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
