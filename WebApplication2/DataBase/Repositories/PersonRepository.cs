using Car.DataBase;
using Car.Domain.DTOs.Person;
using Car.Domain.Model.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace Car.DataBase.Repositories
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
            return _context.Person.Skip((pageNumber - 1) * pageQuantity)
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

        public Person? PersonByEmail(string email)
        {
            return _context.Person.SingleOrDefault(p => p.email == email);
        }
    }
}
