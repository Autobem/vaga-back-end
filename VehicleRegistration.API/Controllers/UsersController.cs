using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Application.Interfaces;

namespace VehicleRegistration.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public UsersController(IApplicationServiceUser ApplicationServiceUser)
        {
            _applicationServiceUser = ApplicationServiceUser;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceUser.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceUser.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Add(userDTO);
                return Ok("Usuário Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Update(userDTO);
                return Ok("Usuário Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Remove(userDTO);
                return Ok("Usuário Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
