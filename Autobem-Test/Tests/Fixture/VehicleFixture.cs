using Bogus;
using Entities.Entities;

namespace Tests.Fixture
{
    public static class VehicleFixture
    {
        public static List<Vehicle> GenerateVehicles(int qtd, List<Owner> owners)
        {
            var dsd = new Bogus.DataSets.Vehicle();
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
    }
}