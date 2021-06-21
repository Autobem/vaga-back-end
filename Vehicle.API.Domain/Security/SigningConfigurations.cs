using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.API.Domain.Security
{
    public class SigningConfigurations
    {
        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                this.Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(this.Key, SecurityAlgorithms.RsaSha256Signature);
        }

        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
