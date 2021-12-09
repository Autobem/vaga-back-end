using AUTOBEM.Domain.Entities;
using AUTOBEM.Domain.Interfaces;
using AUTOBEM.Application.Models;
using AUTOBEM.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using AUTOBEM.Application.Extensions;

namespace AUTOBEM.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly Autenticacao autentica = new();
        private IBaseService<Owner> _baseOwnerService;

        public OwnerController(IBaseService<Owner> baseOwnerService)
        {
            _baseOwnerService = baseOwnerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOwnerModel owner)
        {
            if (owner == null)
                return NotFound();

            return Execute(() => _baseOwnerService.Add<CreateOwnerModel, OwnerModel, OwnerValidator>(owner));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateOwnerModel owner)
        {
            if (owner == null)
                return NotFound();

            return Execute(() => _baseOwnerService.Update<UpdateOwnerModel, OwnerModel, OwnerValidator>(owner));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseOwnerService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get([FromBody] UserModel model)
        {
            return !autentica.AutenticaUsuario(model)
                ? Ok(new { Mensagem = "Usuário não autirizado."})
                : Execute(() => _baseOwnerService.Get<OwnerModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseOwnerService.GetById<OwnerModel>(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
