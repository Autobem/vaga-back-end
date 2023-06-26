using Entities.Enums;

namespace Domain.Models.UserModels;

public class GetUserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public StatusEnum Status { get; set; }
}