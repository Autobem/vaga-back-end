using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Models;
using Domain.Validators;
using Entities.Entities;
using FluentValidation;

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

        public async Task Delete(Guid id)
        {
            await _baseRepository.Delete(id);
        }

        public async Task<List<VehicleModel>> Get()
        {
            var result = await _baseRepository.Get();
            return _mapper.Map<List<VehicleModel>>(result);
        }

        public async Task<VehicleModel> GetById(Guid id)
        {
            var result = await _baseRepository.GetById(id);
            return _mapper.Map<VehicleModel>(result);
        }

        public async Task<VehicleModel> Insert(VehicleModel vehicle)
        {
            var validator = new VehicleModelValidator();
            await validator.ValidateAndThrowAsync(vehicle);

            var insertVehicle = _mapper.Map<Vehicle>(vehicle);
            var result = await _baseRepository.Insert(insertVehicle);
            return _mapper.Map<VehicleModel>(result);
        }

        public async Task Update(VehicleModel vehicle)
        {
            var validator = new UpdateVehicleModelValidator();
            await validator.ValidateAndThrowAsync(vehicle);

            var updateVehicle = _mapper.Map<Vehicle>(vehicle);

            await _baseRepository.Update(updateVehicle);
        }
    }
}