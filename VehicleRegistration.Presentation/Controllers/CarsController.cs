using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Application.Interfaces;

namespace VehicleRegistration.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IApplicationServiceCar _applicationServiceCar;

        public CarsController(IApplicationServiceCar ApplicationServiceCar)
        {
            _applicationServiceCar = ApplicationServiceCar;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceCar.GetAll());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceCar.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] CarDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();


                _applicationServiceCar.Add(produtoDTO);
                return Ok("O veículo foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] CarDTO produtoDTO)
        {

            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceCar.Update(produtoDTO);
                return Ok("O veículo foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] CarDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceCar.Remove(produtoDTO);
                return Ok("O veículo foi removido com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
