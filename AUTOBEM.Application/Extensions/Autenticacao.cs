using AUTOBEM.Application.Models;

namespace AUTOBEM.Application.Extensions
{
    public class Autenticacao
    {
        public bool AutenticaUsuario(UserModel model)
        {
            UserModel user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
            {
                return false;
            }
            string token = TokenService.GenerateToken(user);
            return true;
        }
    }
}
