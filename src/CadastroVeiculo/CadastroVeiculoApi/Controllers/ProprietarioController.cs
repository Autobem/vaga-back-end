using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace CadastroVeiculoApi.Controllers
{
    [ApiController]
    [Authorize]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(IProprietarioService proprietarioService) =>
            _proprietarioService = proprietarioService;

        [HttpGet("v1/getById/{proprietarioId}")]
        public async Task<IActionResult> Get(int proprietarioId)
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = await _proprietarioService.GetById(proprietarioId)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    success = false,
                    errors = new[] { ex.Message }
                });
            }
          
        }


        [HttpGet("v1/getByDocumento/{documento}")]
        public async Task<IActionResult> GetByDocumento(string documento)
        {
            try
            {
                return Ok(
                new
                {
                    success = true,
                    data = await _proprietarioService.GetByDocumento(documento)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    success = false,
                    errors = new[] { ex.Message }
                });
            }
            
        }

        [HttpGet("v1/getByVeiculos/{documento}")]
        public async Task<IActionResult> GetByVeiculos(string documento)
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = await _proprietarioService.GetByVeiculo(documento)
            });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    success = false,
                    errors = new[] { ex.Message }
                });
            }
            
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] ProprietarioDto proprietario)
        {
            try
            {
                return Ok(
                 new
                 {
                     success = true,
                     data = await _proprietarioService.Add(proprietario)
                 });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    success = false,
                    errors = new[] { ex.Message }
                });
            }
            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(ProprietarioUpdateDto proprietario)
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = await _proprietarioService.Put(proprietario)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    success = false,
                    errors = new[] { ex.Message }
                });
            }
         
        }


        [HttpDelete("Delete/{proprietarioId}")]
        public async Task<IActionResult> Delete(int proprietarioId)
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = _proprietarioService.Delete(proprietarioId)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    success = false,
                    errors = new[] { ex.Message }
                });
            }
        }
    }
}
