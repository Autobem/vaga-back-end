using Domain.Models;

namespace Domain.Contracts.Service;

public interface IUserService
{
    Task<UserModel> Insert(UserModel user);

    Task Update(UserModel user);

    Task Delete(Guid id);

    Task<UserModel> GetById(Guid id);

    Task<List<UserModel>> Get();
}