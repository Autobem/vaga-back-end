using Entities.Enums;

namespace Domain.Models.UserModels;

public class UpdateUserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public StatusEnum Status { get; set; }
}