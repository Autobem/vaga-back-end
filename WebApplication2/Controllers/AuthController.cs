using APICars.Application.Services;
using APICars.Domain.DTOs.Person;
using AutoMapper;
using Car.Domain.DTOs.Person;
using Car.Domain.Model.PersonAggregate;
using Microsoft.AspNetCore.Mvc;

namespace APICars.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public AuthController(IPersonRepository personRepository, IMapper mapper) 
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Auth(PersonAuthDTO personAuthDTO)
        {
            var email = personAuthDTO.Email;
            var password = personAuthDTO.Password;

            var personExists = _personRepository.PersonByEmail(email);

            if (personExists == null)
            {
                return BadRequest("Invalid credentials!");
            }

            if (personExists.password != password) 
            {
                return BadRequest("Invalid credentials!");
            }

            var token = TokenService.GenerateToken(new Person());

            return Ok(token);
        }
    }
}
