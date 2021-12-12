using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper;
using CadastroDeVeiculos.Application.DTOs;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands;
using CadastroDeVeiculos.Application.Mediator.UserCQRS.Queries;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Services
{
    public class UserService : IUserService
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public UserService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task CreateAsync(UserDTO entityDTO)
        {
            var userCreateCommand = _mapper.Map<UserCreateCommand>(entityDTO);

            await this._mediator.Send(userCreateCommand);
        }

        public async Task UpdateAsync(UserDTO entityDTO)
        {
            var userUpdateCommand =  this._mapper.Map<UserUpdateCommand>(entityDTO);

            await this._mediator.Send(userUpdateCommand);
        }

        public async Task DeleteAsync(int id)
        {
            var userRemoveCommand = new UserRemoveCommand(id);

            await this._mediator.Send(userRemoveCommand);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var usersQuery = new GetUsersQuery();

            var result = await this._mediator.Send(usersQuery);

            return result.MapTo<IEnumerable<User>, IEnumerable<UserDTO>>();
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            var userQuery = new GetUserByIdQuery(id);

            var result = await this._mediator.Send(userQuery);
            
            return result.MapTo<User, UserDTO>();
        }

        public async Task<UserDTO> GetLogin(string login, string password)
        {
            var userLoginQuery = new GetUserLoginQuery(login, password);

            var result = await this._mediator.Send(userLoginQuery);

            return result.MapTo<User, UserDTO>();
        }

    }
}
