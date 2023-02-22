namespace Cars.Domain.Model.PersonAggregate
{
    public interface IPersonRepository
    {
        void Add(Person person);

        List<Person> Get(int pageNumber, int pageQuantity);

        Person? Get(int id);
    }
}
