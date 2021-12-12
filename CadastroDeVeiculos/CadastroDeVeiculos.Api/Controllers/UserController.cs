using CadastroDeVeiculos.Api.Security.Services;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using CadastroDeVeiculos.Business.NotificationHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<INotificationContext>))]
        public async Task Post([FromBody] UserDTO request)
        {
            await _userService.CreateAsync(request);
        }
    }
}
