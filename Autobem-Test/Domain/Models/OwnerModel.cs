namespace Domain.Models;

public class OwnerModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string CNH { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime InclusionDate { get; set; }
    public DateTime LastChange { get; set; }
}