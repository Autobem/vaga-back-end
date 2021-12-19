using System;

namespace CadastroDeVeiculos.WebApi.Model
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
