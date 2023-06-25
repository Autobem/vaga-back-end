using Domain.Models;
using Domain.Models.UserModels;

namespace Domain.Contracts.Service;

public interface IUserService
{
    Task<GetUserModel> Insert(CreateUserModel user);

    Task Update(UpdateUserModel user);

    Task Delete(Guid id);

    Task<GetUserModel> GetById(Guid id);

    Task<List<GetUserModel>> Get();
    Task<UserModel> GetUserLogin(string userEmail);
}