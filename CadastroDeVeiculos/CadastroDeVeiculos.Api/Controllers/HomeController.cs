using CadastroDeVeiculos.Api.Security.Services;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Business.NotificationHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class HomeController : ControllerBase
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserDTO request)
        {
            await this._userService.GetLogin(request.LoginData, request.Password);

            if (request == null)
            {
                return NotFound(new { message = "Usuário ou senha inválida" });
            }

            var token = TokenService.GenerateToken(request);
            request.Password = "";
            return new
            {
                request = request,
                token = token
            };
        }

       

    }
}
