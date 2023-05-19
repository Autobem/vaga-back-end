namespace VehicleRegistry.Application.DataTransferObjects;

/// <summary>
/// Objeto de transferência de dados de usuário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class UserData : Data
{
    /// <summary>
    /// O nome de usuário.
    /// </summary>
    public string UserName { get; set; } = "";

    /// <summary>
    /// O e-mail do usuário.
    /// </summary>
    public string Email { get; set; } = "";

    /// <summary>
    /// A senha do usuário.
    /// </summary>
    public string Password { get; set; } = "";
}