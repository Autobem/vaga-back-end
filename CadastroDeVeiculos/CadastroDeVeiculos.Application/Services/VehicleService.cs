using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _vehicleRepository;
        private IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            this._vehicleRepository = vehicleRepository;
            this._mapper = mapper;
        }

        public async Task CreateAsync(VehicleDTO entity)
        {
            var userEntity = _mapper.Map<Vehicle>(entity);
            await this._vehicleRepository.CreateAsync(userEntity);

        }

        public async Task UpdateAsync(VehicleDTO entity)
        {
            if (this._vehicleRepository.Exist(x => x.Id == entity.Id))
            {
                var userEntity = this._mapper.Map<Vehicle>(entity);
                await this._vehicleRepository.UpdateAsync(userEntity);
            }

        }

        public async Task DeleteAsync(int id)
        {
            var userEntity = this._vehicleRepository.GetByIdAsync(id).Result;
            await this._vehicleRepository.DeleteAsync(userEntity.Id);
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllAsync(int pageSize, int pageActual)
        {
            var list = await this._vehicleRepository.GetAllAsync(pageSize, pageActual);
            return list.MapTo<IEnumerable<Vehicle>, IEnumerable<VehicleDTO>>();
        }

        public async Task<VehicleDTO> GetAsync(int id)
        {
            var entity = await this._vehicleRepository.GetByIdAsync(id);
            return entity.MapTo<Vehicle, VehicleDTO>();
        }
    }
}
