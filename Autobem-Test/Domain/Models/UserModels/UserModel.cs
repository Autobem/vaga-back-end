using Entities.Enums;

namespace Domain.Models.UserModels;

public class UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public StatusEnum Status { get; set; }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }
}