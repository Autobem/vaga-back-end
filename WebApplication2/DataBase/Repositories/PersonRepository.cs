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
            return _context.Person.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(b =>
                new PersonDTO()
                {
                    Id = b.id,
                    Name = b.name,
                    Email= b.email,
                })
                .ToList();
        }

        public Person? Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool PersonExistsByEmail(string email)
        {
            return _context.Person.Any(x => x.email == email);
        }
    }
}
