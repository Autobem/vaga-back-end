using Microsoft.AspNetCore.Identity;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de usuário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class UserService : Service
{
    /// <summary>
    /// O gerenciador de usuário.
    /// </summary>
    private UserManager<User> userManager;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="userManager">O gerenciador de usuário.</param>
    public UserService(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="userData">Os dados do novo proprietário.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task<IdentityResult> CreateUser(UserData userData)
    {
        User user = new User {
            UserName = userData.UserName,
            Email = userData.Email
        };

        return await this.userManager.CreateAsync(user, userData.Password);
    }

    /// <summary>
    /// Pega determinado usuário pelas credenciais.
    /// </summary>
    /// <param name="email">O e-mail do usuário.</param>
    /// <param name="password">A senha do usuário.</param>
    /// <returns>Os dados do usuário solicitado.</returns>
    public async Task<User?> GetUserByCredentials(string email, string password)
    {
        User? user = await this.userManager.FindByEmailAsync(email);
        bool validPassword = false;
        if (user != null) {
            validPassword = await this.userManager.CheckPasswordAsync(
                user,
                password
            );
        }

        return (validPassword) ? user : null;
    }
}