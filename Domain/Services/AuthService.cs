using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Domain.ValueObjects;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de autenticação do usuário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class AuthService : Service
{
    /// <summary>
    /// Entidade de autenticação.
    /// </summary>
    private Auth auth;

    /// <summary>
    /// Serviço de usuário.
    /// </summary>
    private UserService userService;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="auth">A entidade de autenticação.</param>
    /// <param name="userService">O serviço de usuário.</param>
    public AuthService(Auth auth, UserService userService)
    {
        this.auth = auth;
        this.userService = userService;
    }

    /// <summary>
    /// Efetiva a autenticação do usuário.
    /// </summary>
    /// <param name="credentials">As credenciais do usuário.</param>
    /// <returns>O novo token de acesso.</returns>
    public async Task<string> Authenticate(LoginData credentials)
    {
        string token = "";

        // Valida as credenciais do usuário.
        User? user = await this.userService.GetUserByCredentials(
            credentials.Email,
            credentials.Password
        );
        if (user != null) {
            // Resgata o token de acesso.
            token = this.GenerateAccessToken(user);
        }

        return token;
    }

    /// <summary>
    /// Gera um novo token de acesso.
    /// </summary>
    /// <param name="user">A entidade do usuário.</param>
    /// <returns>O token de acesso gerado.</returns>
    public string GenerateAccessToken(User user)
    {
        // Gera as credenciais do token a partir da chave de segurança.
        var credentials = new SigningCredentials(
            this.auth.Key,
            SecurityAlgorithms.HmacSha256
        );

        // Define as informações de validação do token.
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Configura o novo token de acesso.
        var token = new JwtSecurityToken(
            issuer: this.auth.Issuer,
            audience: this.auth.Audience,
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}