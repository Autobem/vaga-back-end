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
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task CreateAsync(UserDTO entity)
        {
            var userEntity = _mapper.Map<User>(entity);
            await this._userRepository.CreateAsync(userEntity);

        }

        public async Task UpdateAsync(UserDTO entity)
        {
                var userEntity = this._mapper.Map<User>(entity);
                await this._userRepository.UpdateAsync(userEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var userEntity = this._userRepository.GetByIdAsync(id).Result;
            await this._userRepository.DeleteAsync(userEntity.Id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync(int pageSize, int pageActual)
        {
            var list = await this._userRepository.GetAllAsync(pageSize, pageActual);
            return list.MapTo<IEnumerable<User>, IEnumerable<UserDTO>>();
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            var entity = await this._userRepository.GetByIdAsync(id);
            return entity.MapTo<User, UserDTO>();
        }
    }
}
