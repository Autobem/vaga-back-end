using Entities.Enums;

namespace Domain.Models;

public class CreateUserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public StatusEnum Status { get; set; }
}