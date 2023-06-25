using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Models;
using Entities.Entities;

namespace Domain.Service;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _repository;

    public UserService(IBaseRepository<User> repository)
    {
        _repository = repository;
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserModel>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Insert(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task Update(UserModel user)
    {
        throw new NotImplementedException();
    }
}