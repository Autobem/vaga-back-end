using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Application.Interfaces;

namespace VehicleRegistration.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IApplicationServiceClient _applicationServiceClient;

        public ClientsController(IApplicationServiceClient ApplicationServiceClient)
        {
            _applicationServiceClient = ApplicationServiceClient;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceClient.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceClient.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ClientDTO clientDTO)
        {
            try
            {
                if (clientDTO == null)
                    return NotFound();

                _applicationServiceClient.Add(clientDTO);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ClientDTO clientDTO)
        {
            try
            {
                if (clientDTO == null)
                    return NotFound();

                _applicationServiceClient.Update(clientDTO);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ClientDTO clientDTO)
        {
            try
            {
                if (clientDTO == null)
                    return NotFound();

                _applicationServiceClient.Remove(clientDTO);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
