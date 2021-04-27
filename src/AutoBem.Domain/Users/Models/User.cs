using BuildingBlocks.Domain.Models;
using System;

namespace AutoBem.Domain.Users.Models
{
    public class User : IModel
    {
        public static string UsernameAdmin { get; set; } = "administrador";
        public static string PasswordAdmin { get; set; } = "12345678";


        public Guid? Id { get; set; }

        public String Name { get; set; }

        public String Username { get; set; }

        public String Password { private get; set; }

        public bool TrySignin(string password)
        {
            return password == this.Password;
        }
    }
}
