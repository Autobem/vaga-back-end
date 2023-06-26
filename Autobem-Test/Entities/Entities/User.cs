using Entities.Enums;

namespace Entities.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public StatusEnum Status { get; set; }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }
}