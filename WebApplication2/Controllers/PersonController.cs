using Cars.Application.ViewModel;
using Cars.Domain.Model.PersonAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PersonViewModel personView)
        {
            var created_on = DateTime.Now.ToUniversalTime();
            var car = new Person(personView.Name, personView.Email, personView.Password, created_on);

            _personRepository.Add(car);

            return Ok();
        }
    }
}
