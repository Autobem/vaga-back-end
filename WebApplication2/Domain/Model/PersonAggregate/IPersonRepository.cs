using Cars.Domain.DTOs;

namespace Cars.Domain.Model.PersonAggregate
{
    public interface IPersonRepository
    {
        bool Add(Person person);
        List<PersonDTO> Get(int pageNumber, int pageQuantity);

        Person? Get(int id);

        bool PersonExistsByEmail(string email);

        bool UpdatePerson(Person person);

        bool DeletePerson(Person person);
        
    }
}
