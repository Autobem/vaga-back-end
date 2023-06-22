using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Entities.Entities;

namespace Domain.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IBaseRepository<Vehicle> _baseRepository;
        private readonly IMapper _mapper;

        public VehicleService(IBaseRepository<Vehicle> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public Task Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> Get()
        {
            throw new NotImplementedException();
        }

        public Task GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}