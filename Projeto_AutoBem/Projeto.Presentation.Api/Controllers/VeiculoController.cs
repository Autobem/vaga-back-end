using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoApplicationService veiculoApplicationService;

        public VeiculoController(IVeiculoApplicationService veiculoApplicationService)
        {
            this.veiculoApplicationService = veiculoApplicationService;
        }

        [HttpPost]
        public IActionResult Post(VeiculoCadastroModel model)
        {
            try
            {
                veiculoApplicationService.Create(model);
                return Ok("Veículo cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(VeiculoEdicaoModel model)
        {
            try
            {
                veiculoApplicationService.Update(model);
                return Ok("Veículo atualizado com sucesso.");
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
                var model = new VeiculoExclusaoModel() { IdVeiculo = id };

                veiculoApplicationService.Delete(model);
                return Ok("Veículo excluído com sucesso.");
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
                return Ok(veiculoApplicationService.GetAll());
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
                return Ok(veiculoApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
