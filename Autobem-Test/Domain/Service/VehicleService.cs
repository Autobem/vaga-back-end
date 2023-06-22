using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Models;
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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleModel>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> Insert(VehicleModel vehicle)
        {
            throw new NotImplementedException();
        }

        public Task Update(VehicleModel vehicle)
        {
            throw new NotImplementedException();
        }
    }
}