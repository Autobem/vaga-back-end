using Car.Domain.DTOs.Person;

namespace Car.Domain.Model.PersonAggregate
{
    public interface IPersonRepository
    {
        bool Add(Person person);
        List<PersonDTO> Get(int pageNumber, int pageQuantity);

        Person? Get(int id);

        bool PersonExistsByEmail(string email);

        bool UpdatePerson(Person person);

        bool DeletePerson(Person person);

        Person? PersonByEmail(string email);
    }
}
