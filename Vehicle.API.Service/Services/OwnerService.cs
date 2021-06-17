using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Owner;
using Vehicles.API.Domain.Entities;
using Vehicles.API.Domain.Interfaces;
using Vehicles.API.Domain.Interfaces.Services.Owner;

namespace Vehicles.API.Service.Services
{
    public class OwnerService : IOwnerService
    {
        private IRepository<Owner> _repository;
        private readonly IMapper _mapper;

        public OwnerService(IRepository<Owner> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<OwnerDto> Get(Guid id)
        {
            var entity = await _repository.GetOnwer(id);
            //var entity = await _repository.SelectAsync(id);

            //var vehicles = await _repository.GetAllVehicles();
            //vehicles;
            //entity;

            return _mapper.Map<OwnerDto>(entity);
        }

        public async Task<IEnumerable<OwnerDto>> GetAll()
        {
            var listEntity = await _repository.GetOnwers();
            //var listEntity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<OwnerDto>>(listEntity);
        }

        public async Task<OwnerDto> Post(OwnerDtoCreate owner)
        {
            //IQueryable<Owner> query = _mapper.Map<>
            var entity = _mapper.Map<Owner>(owner);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<OwnerDto>(result);
        }

        public async Task<OwnerDto> Put(OwnerDtoUpdate owner)
        {
            var entity = _mapper.Map<Owner>(owner);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<OwnerDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
