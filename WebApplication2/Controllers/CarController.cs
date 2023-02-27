using APICars.Domain.DTOs.Car;
using AutoMapper;
using Car.DataBase.Repositories;
using Car.Domain.DTOs.Car;
using Car.Domain.DTOs.Person;
using Car.Domain.Model.CarAggregate;
using Car.Domain.Model.PersonAggregate;
using Cars.Domain.DTOs.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] CarCreateDTO carCreateDTO)
        {
            var ownerId = carCreateDTO.Owner_id;
            var person = _personRepository.Get(ownerId);

            if (person == null)
            {
                return BadRequest("Owner not found!");
            }

            var carMap = _mapper.Map<CarCreateDTO, Vehicle>(carCreateDTO);

            _carRepository.Add(carMap);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            var cars = _carRepository.Get(pageNumber, pageQuantity);
            return Ok(cars);
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult CarById(int id)
        {
            var car = _carRepository.Get(id);

            if (car == null)
            {
                return NotFound("Car not found!");
            }

            var carMap = _mapper.Map<Vehicle, CarDTO>(car);

            return Ok(carMap);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CarUpdateDTO carUpdateDTO)
        {
            if (carUpdateDTO == null)
            {
                return BadRequest("No body in request!");
            }

            var car = _carRepository.Get(id);
            if (car == null)
            {
                return BadRequest("Car not found!");
            }

            var ownerId = carUpdateDTO.Owner_id;
            var owner = _personRepository.Get(ownerId);
            if (owner == null)
            {
                return BadRequest("Owner not found!");
            }

            carUpdateDTO.Id = id;
            carUpdateDTO.created_on = car.created_on.ToUniversalTime();

            var carMap = _mapper.Map<CarUpdateDTO, Vehicle>(carUpdateDTO);


            _carRepository.UpdateCar(carMap);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = _carRepository.Get(id);
            if (car == null)
            {
                return BadRequest("Car not found!");
            }

            _carRepository.DeleteCar(car);

            return Ok();
        }

    }
    }
