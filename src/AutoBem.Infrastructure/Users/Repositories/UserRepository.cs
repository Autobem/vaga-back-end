using AutoBem.Domain.Users;
using AutoBem.Domain.Users.Models;
using BuildingBlocks.Ioc.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBem.Infrastructure.Users.Repositories
{
    [Injectable]
    public class UserRepository : IUserRepository
    {
        private List<User> Users { get; } = new List<User>()
        {
            new User()
            {
                Id = Guid.Parse("083d292a-2889-4c9a-90f7-5d973bde93aa"),
                Name = "Administrador do sistema",
                Username = User.UsernameAdmin,
                Password = User.PasswordAdmin
            }
        };

        public bool ExistUserName(string username)
        {
            return this.Users
                .Where(e => e.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                .Any();
        }

        public User GetByUserName(string userName)
        {
            return this.Users
                .Where(e => e.Username.Equals(userName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
        }
    }
}
