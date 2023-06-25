using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Models;
using Entities.Entities;

namespace Domain.Service;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _repository;
    private readonly IPasswordService _passwordService;

    public UserService(IBaseRepository<User> repository, IPasswordService passwordService)
    {
        _repository = repository;
        _passwordService = passwordService;
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CreateUserModel>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<CreateUserModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CreateUserModel> Insert(CreateUserModel user)
    {
        throw new NotImplementedException();
    }

    public Task Update(CreateUserModel user)
    {
        throw new NotImplementedException();
    }
}