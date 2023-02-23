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

            var personMap = _mapper.Map<PersonDTO, Person>(personDTO);

            //var car = new Person(personView.Name, personView.Email, personView.Password, created_on);

            _personRepository.Add(personMap);

            return Ok();
        }
    }
}
