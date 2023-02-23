namespace Cars.Domain.Model.CarAggregate
{
    public interface ICarRepository
    {
        void Add(Car car);

        List<Car> Get(int pageNumber, int pageQuantity);
    }
}
