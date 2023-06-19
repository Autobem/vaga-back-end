using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroVeiculoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService  _veiculoService;

        public VeiculoController(IVeiculoService veiculoService) =>
            _veiculoService = veiculoService;

        [HttpGet("v1/getById/{veiculoId}")]
        public async Task<IActionResult> Get(int veiculoId)
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = await _veiculoService.GetById(veiculoId)
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


        [HttpGet("v1/getByDocumento/{renavam}")]
        public async Task<IActionResult> GetByDocumento(long renavam)
        {
            try
            {
                return Ok(
                new
                {
                    success = true,
                    data = await _veiculoService.GetByDocumento(renavam)
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
        public async Task<IActionResult> Post([FromBody] VeiculoDto veiculo)
        {
            try
            {
                return Ok(
                 new
                 {
                     success = true,
                     data = await _veiculoService.Add(veiculo)
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
        public async Task<IActionResult> Put(VeiculoUpdateDto veiculo)
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = await _veiculoService.Put(veiculo)
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


        [HttpDelete("Delete/{veiculoId}")]
        public async Task<IActionResult> Delete(int veiculoId)
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = _veiculoService.Delete(veiculoId)
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
