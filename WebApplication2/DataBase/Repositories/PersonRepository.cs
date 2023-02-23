using Car.DataBase;
using Cars.Domain.DTOs;
using Cars.Domain.Model.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace Cars.DataBase.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public readonly ConnectionContext _context = new ConnectionContext();

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Add(Person person)
        {
   
            _context.Person.Add(person);
            return Save();
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
            var person = _context.Person.Find(id);

            return person;
        }

        public bool PersonExistsByEmail(string email)
        {
            return _context.Person.Any(x => x.email == email);
        }

        public bool UpdatePerson(Person person)
        {
            _context.Person.Update(person);
            return Save();
        }

        public bool DeletePerson(Person person)
        {
            _context.Remove(person);
            return Save();
        }
    }
}
