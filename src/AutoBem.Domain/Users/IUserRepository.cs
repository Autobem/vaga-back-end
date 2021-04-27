using AutoBem.Domain.Users.Models;

namespace AutoBem.Domain.Users
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);

        bool ExistUserName(string username);
    }
}
