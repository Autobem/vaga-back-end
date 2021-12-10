using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Proprietarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioApplicationService ProprietarioApplicationService;

        public ProprietarioController(IProprietarioApplicationService ProprietarioApplicationService)
        {
            this.ProprietarioApplicationService = ProprietarioApplicationService;
        }       

        [HttpPost]
        public IActionResult Post(ProprietarioCadastroModel model)
        {
            try
            {
                ProprietarioApplicationService.Create(model);
                return Ok("Proprietário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ProprietarioEdicaoModel model)
        {
            try
            {
                ProprietarioApplicationService.Update(model);
                return Ok("Proprietário atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var model = new ProprietarioExclusaoModel() { IdProprietario = id };

                ProprietarioApplicationService.Delete(model);
                return Ok("Proprietário excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(ProprietarioApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(ProprietarioApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
