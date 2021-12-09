using AUTOBEM.Application.Models;
using System.Collections.Generic;
using System.Linq;

namespace AUTOBEM.Application.Extensions
{
    public static class UserRepository
    {
        public static UserModel Get(string username, string password)
        {
            List<UserModel> users = new()
            {
                new UserModel { Id = 1, Username = "batman", Password = "batman", Role = "gerente" },
                new UserModel { Id = 2, Username = "robin", Password = "robin", Role = "empregado" },
                new UserModel { Id = 3, Username = "eduardo", Password = "rezende", Role = "gerente" }
            };
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
