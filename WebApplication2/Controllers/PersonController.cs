using Cars.Application.ViewModel;
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
        public IActionResult Add([FromBody] PersonDTO personDTO)
        {

            if (_personRepository.PersonExistsByEmail(personDTO.Email))
            {
                return BadRequest("User already exists!");
            }

            var personMap = _mapper.Map<PersonDTO, Person>(personDTO);

            _personRepository.Add(personMap);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {

            var people = _personRepository.Get(pageNumber, pageQuantity);

            return Ok(people);
        }
    }
}
