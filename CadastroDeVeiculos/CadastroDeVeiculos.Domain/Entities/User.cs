using CadastroDeVeiculos.Domain.Enums;
using CadastroDeVeiculos.Domain.Validations;

namespace CadastroDeVeiculos.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string LoginData { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }

        public User(string loginData, string email, string password, Role role)
        {
            this.LoginData = loginData;
            this.Email = email;
            this.Password = password;
            this.Role = role;

            Validate(this, new UserValidation());
        }

        public void UserUpdate(string loginData, string email, string password, Role role)
        {
            if (loginData != null)
            {
                this.LoginData = loginData;
            }

            if (email != null)
            {
                this.Email = email;
            }

            if (role != Role)
            {
                this.Role = role;
            }

            if (password != null)
            {
                this.Password = password;
            }

            Validate(this, new UserValidation());
        }
    }
}
