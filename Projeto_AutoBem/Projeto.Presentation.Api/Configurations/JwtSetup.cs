using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Configurations
{
    public static class JwtSetup
    {
        public static void AddJwtSetup(IServiceCollection services, IConfiguration configuration)
        {
            //lendo o código de segurança (Secret) contido no appsettings.json
            var settingsSection = configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(settingsSection);

            var appSettings = settingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new TokenService(appSettings));
        }

        public static void UseJwtSetup(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }

    //classe para ler o valor mapeado no appsettings.json
    public class JwtSettings
    {
        public string SecretKey { get; set; }
    }

    //classe para gerar o TOKEN encriptado
    public class TokenService
    {
        private readonly JwtSettings appSettings;

        public TokenService(JwtSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            //conteudo do TOKEN
            var tokenDescription = new SecurityTokenDescriptor
            {
                //definições do usuário
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),

                //tempo de validade do TOKEN
                Expires = DateTime.Now.AddDays(1),

                //criptografia do token
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
