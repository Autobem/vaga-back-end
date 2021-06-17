using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Vehicle;
using Vehicles.API.Domain.Entities;
using Vehicles.API.Domain.Interfaces;
using Vehicles.API.Domain.Interfaces.Services.Vehicle;

namespace Vehicles.API.Service.Services
{
    public class VehicleService : IVehicleService
    {
        private IRepository<Vehicle> _respository;
        private readonly IMapper _mapper;

        public VehicleService(IRepository<Vehicle> respository, IMapper mapper)
        {
            this._respository = respository;
            this._mapper = mapper;
        }

        public async Task<VehicleDto> Get(Guid id)
        {
            var entity = await _respository.SelectAsync(id);

            return _mapper.Map<VehicleDto>(entity);
        }

        public async Task<IEnumerable<VehicleDto>> GetAll()
        {
            var listEntity = await _respository.SelectAsync();

            return _mapper.Map<IEnumerable<VehicleDto>>(listEntity);
        }

        public async Task<VehicleDto> Post(VehicleDtoCreate vehicle)
        {
            var entity = _mapper.Map<Vehicle>(vehicle);
            var result = await _respository.InsertAsync(entity);

            return _mapper.Map<VehicleDto>(result);
        }

        public async Task<VehicleDto> Put(VehicleDtoUpdate vehicle)
        {
            var entity = _mapper.Map<Vehicle>(vehicle);
            var result = await _respository.UpdateAsync(entity);

            return _mapper.Map<VehicleDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _respository.DeleteAsync(id);
        }
    }
}
