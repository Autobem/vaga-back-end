using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //atributo
        private readonly IUsuarioApplicationService usuarioApplicationService;

        public UsuarioController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(UsuarioCadastroModel model)
        {
            try
            {
                usuarioApplicationService.Create(model);
                return Ok("Usuário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsuario()
        {
            try
            {
                //buscar o usuario autenticado pelo email
                var email = User.Identity.Name;
                return Ok(usuarioApplicationService.GetByEmail(email));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
