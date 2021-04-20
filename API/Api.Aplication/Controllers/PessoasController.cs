using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.Pessoa;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Aplication.Controllers
{

    [Route("api/v1/pessoas")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}", Name="pegar_por_id")]
        public async Task<ActionResult> PegarPorId(int id){
            if (!ModelState.IsValid){
                return BadRequest();
            }

            try
            {
                return Ok(await _service.GetAsync(id));
            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] PessoaDTO pessoa){
            if (!ModelState.IsValid){
                return BadRequest();
            }

            try
            {
                var result = await _service.PostAsync(pessoa);

                if (result!=null)
                {
                    return Created(new Uri(Url.Link("pegar_por_id", new {id=result.Id})), result);
                }
                else return BadRequest();
            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar([FromBody] PessoaDTOPutRequest pessoa){
            if (!ModelState.IsValid){
                return BadRequest();
            }

            try
            {
                var result = await _service.PutAsync(pessoa);

                if (result!=null) return Ok(result);
                else return BadRequest();
            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id){
            if (!ModelState.IsValid){
                return BadRequest();
            }

            try
            {
                int result = await _service.DeleteAsync(id);

                if (result!=0) return Ok(result);
                else return BadRequest();
            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}