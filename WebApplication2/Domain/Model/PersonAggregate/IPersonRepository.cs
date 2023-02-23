using Cars.Domain.DTOs;

namespace Cars.Domain.Model.PersonAggregate
{
    public interface IPersonRepository
    {
        void Add(Person person);
        List<PersonDTO> Get(int pageNumber, int pageQuantity);
        Person? Get(int id);

        bool PersonExistsByEmail(string email);
    }
}
