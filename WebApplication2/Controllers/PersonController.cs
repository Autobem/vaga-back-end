using Cars.Domain.Model.PersonAggregate;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Cars.Domain.DTOs;

namespace Cars.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PersonUpdateDTO personCreateDTO)
        {

            if (_personRepository.PersonExistsByEmail(personCreateDTO.Email))
            {
                return BadRequest("User already exists!");
            }

            var personMap = _mapper.Map<PersonUpdateDTO, Person>(personCreateDTO);

            _personRepository.Add(personMap);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {

            var people = _personRepository.Get(pageNumber, pageQuantity);

            return Ok(people);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult PersonById(int id)
        {
            var person = _personRepository.Get(id);

            if (person == null)
            {
                return NotFound("User not found!");
            }

            var personMap = _mapper.Map<Person, PersonDTO>(person);

            return Ok(personMap);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PersonUpdateDTO personUpdateDTO)
        {
            if (personUpdateDTO == null)
            {
                return BadRequest("No body in request!");
            }

            var person = _personRepository.Get(id);
            if (person == null)
            {
                return BadRequest("User not found!");
            }

            personUpdateDTO.Id = id;

            var personMap = _mapper.Map<PersonUpdateDTO, Person>(personUpdateDTO);


            _personRepository.UpdatePerson(personMap);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var person = _personRepository.Get(id);
            if (person == null)
            {
                return BadRequest("User not found!");
            }

            _personRepository.DeletePerson(person);

            return Ok();
        }
    }
}
