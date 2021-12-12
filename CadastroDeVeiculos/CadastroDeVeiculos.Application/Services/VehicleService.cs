using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Commands;
using CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Queries;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public VehicleService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task CreateAsync(VehicleDTO entityDTO)
        {
            var vehicleCreateCommand = _mapper.Map<VehicleCreateCommand>(entityDTO);

            await this._mediator.Send(vehicleCreateCommand);
        }

        public async Task UpdateAsync(VehicleDTO entityDTO)
        {
            var vehicleUpdateCommand = this._mapper.Map<VehicleUpdateCommand>(entityDTO);

            await this._mediator.Send(vehicleUpdateCommand);
        }

        public async Task DeleteAsync(int id)
        {
            var vehicleRemoveCommand = new VehicleRemoveCommand(id);

            await this._mediator.Send(vehicleRemoveCommand);
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllAsync()
        {
            var vehiclesQuery = new GetVehiclesQuery();

            var result = await this._mediator.Send(vehiclesQuery);

            return result.MapTo<IEnumerable<Vehicle>, IEnumerable<VehicleDTO>>();
        }

        public async Task<VehicleDTO> GetAsync(int id)
        {
            var vehicleQuery = new GetVehicleByIdQuery(id);

            var result = await this._mediator.Send(vehicleQuery);

            return result.MapTo<Vehicle, VehicleDTO>();
        }
    }
}
