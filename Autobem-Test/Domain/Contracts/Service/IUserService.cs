using Domain.Models;

namespace Domain.Contracts.Service;

public interface IUserService
{
    Task<CreateUserModel> Insert(CreateUserModel user);

    Task Update(CreateUserModel user);

    Task Delete(Guid id);

    Task<CreateUserModel> GetById(Guid id);

    Task<List<CreateUserModel>> Get();
}