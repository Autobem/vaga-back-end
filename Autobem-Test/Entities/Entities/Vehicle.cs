using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

[PrimaryKey("Id")]
public class Vehicle
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Year { get; set; }
    public Guid OwnerId { get; set; }
    public Owner Owner { get; set; }
}