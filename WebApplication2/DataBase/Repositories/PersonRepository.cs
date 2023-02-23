using Car.DataBase;
using Cars.Domain.DTOs;
using Cars.Domain.Model.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace Cars.DataBase.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Person person)
        {
   
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public List<PersonDTO> Get(int pageNumber, int pageQuantity)
        {
            throw new NotImplementedException();
        }

        public Person? Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
