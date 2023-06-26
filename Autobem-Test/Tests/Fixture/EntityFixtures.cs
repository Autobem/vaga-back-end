using Bogus;
using Bogus.Extensions.Brazil;
using Entities.Entities;
using Entities.Enums;

namespace Tests.Fixture;

public static class EntityFixtures
{
    public static List<Owner> GenerateOwners(int qtd)
    {
        var owners = new Faker<Owner>()
            .RuleFor(o => o.Id, f => Guid.NewGuid())
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Cpf, f => f.Person.Cpf())
            .RuleFor(o => o.CNH, f => f.Person.Cpf())
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.BirthDate, f => FixtureUtils.RuleForDates(f))
            .RuleFor(o => o.InclusionDate, f => FixtureUtils.RuleForDates(f))
            .RuleFor(o => o.LastChange, f => FixtureUtils.RuleForDates(f));

        return owners.Generate(qtd);
    }

    public static List<Vehicle> GenerateVehicles(int qtd, List<Owner> owners)
    {
        var vehicles = new Faker<Vehicle>()
            .RuleFor(v => v.Id, f => Guid.NewGuid())
            .RuleFor(v => v.Plate, f => f.PickRandom(FixtureUtils.CarPlateList()))
            .RuleFor(v => v.Name, f => f.Vehicle.Model())
            .RuleFor(v => v.Brand, f => f.Vehicle.Manufacturer())
            .RuleFor(v => v.Color, f => f.Commerce.Color())
            .RuleFor(v => v.City, f => f.Address.City())
            .RuleFor(v => v.State, f => f.Address.State())
            .RuleFor(v => v.Year, f => FixtureUtils.RuleForDates(f).Year.ToString())
            .RuleFor(v => v.OwnerId, f => f.PickRandom(owners.Select(o => o.Id)));

        return vehicles.Generate(qtd);
    }

    public static List<User> GenerateUsers(int qtd)
    {
        var users = new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => f.Internet.Password())
            .RuleFor(u => u.PasswordSalt, f => f.Internet.Password())
            .RuleFor(u => u.Status, f => f.PickRandom<StatusEnum>());

        return users.Generate(qtd);
    }
}