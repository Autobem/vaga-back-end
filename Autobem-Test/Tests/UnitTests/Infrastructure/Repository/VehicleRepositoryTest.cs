using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tests.Fixture;

namespace Tests.UnitTests.Infrastructure.Repository;

[Collection("Repository Unit Tests")]
public class VehicleRepositoryTest : IDisposable
{
    private readonly DbContextOptions _options;

    private const int POPULATED_VEHICLES = 10;
    private const int EMPTY_VEHICLES = 0;
    private const string NEW_NAME = "New Name";

    public VehicleRepositoryTest()
    {
        _options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .EnableSensitiveDataLogging()
            .Options;
    }

    public async void Dispose()
    {
        using (var context = new BaseContext(_options))
        {
            var owners = await context.Set<Owner>().ToListAsync();
            var vehicles = await context.Set<Vehicle>().ToListAsync();

            context.Set<Owner>().RemoveRange(owners);
            context.Set<Vehicle>().RemoveRange(vehicles);
            await context.SaveChangesAsync();
        }
    }

    #region Get

    [Fact]
    public async Task Get_OnEmptyDatabase_ReturnEmptyList()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var sut = new BaseRepository<Vehicle>(context);

            // Act
            var result = await sut.Get();

            // Assert
            result.Count.Should().Be(EMPTY_VEHICLES);
        }
    }

    [Fact]
    public async Task Get_OnPopulatedDatabase_ReturnAllEntities()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owners = EntityFixtures.GenerateOwners(POPULATED_VEHICLES);
            await context.Set<Owner>().AddRangeAsync(owners);
            await context.SaveChangesAsync();

            var vehicles = EntityFixtures.GenerateVehicles(POPULATED_VEHICLES, owners);
            await context.Set<Vehicle>().AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            var sut = new BaseRepository<Vehicle>(context);

            // Act
            var result = await sut.Get();

            Debug.WriteLine("Expected Vehicles");
            vehicles.ForEach(v => Debug.WriteLine($"{v.Id} {v.Name}"));

            Debug.WriteLine("\nActual Vehicles");
            result.ForEach(v => Debug.WriteLine($"{v.Id} {v.Name}"));

            // Assert
            result.Count.Should().Be(POPULATED_VEHICLES);
        }
    }

    #endregion Get

    #region GetById

    [Fact]
    public async Task GetById_OnVehicleNotFound_ReturnNull()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var sut = new BaseRepository<Vehicle>(context);

            // Act
            var result = await sut.GetById(new Guid());

            // Assert
            result.Should().BeNull();
        }
    }

    [Fact]
    public async Task GetById_OnOwnerFound_ReturnOwner()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owner = EntityFixtures.GenerateOwners(1);
            var expected = EntityFixtures.GenerateVehicles(1, owner).FirstOrDefault();
            await context.Set<Owner>().AddAsync(owner.FirstOrDefault());
            await context.Set<Vehicle>().AddAsync(expected);
            var sut = new BaseRepository<Vehicle>(context);

            // Act
            var actual = await sut.GetById(expected.Id);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }

    #endregion GetById

    #region Insert

    [Fact]
    public async Task Insert_OnVehicleInserted_CallGetById_ReturnSameOwner()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owner = EntityFixtures.GenerateOwners(1);
            var expected = EntityFixtures.GenerateVehicles(1, owner).FirstOrDefault();
            await context.Set<Owner>().AddAsync(owner.FirstOrDefault());
            await context.Set<Vehicle>().AddAsync(expected);
            var sut = new BaseRepository<Vehicle>(context);

            // Act
            await sut.Insert(expected);

            // Assert
            var actual = await context.Set<Vehicle>().FindAsync(expected.Id);
            actual.Should().BeEquivalentTo(expected);
        }
    }

    [Fact]
    public async Task Insert_OnVehicleInserted_ReturnVehicleInserted()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owner = EntityFixtures.GenerateOwners(1);
            var expected = EntityFixtures.GenerateVehicles(1, owner).First();
            var sut = new BaseRepository<Vehicle>(context);

            // Act
            var actual = await sut.Insert(expected);

            // Assert
            actual.Should().BeOfType<Vehicle>();
            actual.Should().BeEquivalentTo(expected);
        }
    }

    #endregion Insert

    #region Update

    [Fact]
    public async Task Update_OnVehicleInserted_UpdateItsName_ReturnVehicleWithNewName()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owner = EntityFixtures.GenerateOwners(1);
            var expected = EntityFixtures.GenerateVehicles(1, owner).FirstOrDefault();
            await context.Set<Owner>().AddAsync(owner.FirstOrDefault());
            await context.Set<Vehicle>().AddAsync(expected);
            await context.SaveChangesAsync();
            var sut = new BaseRepository<Vehicle>(context);

            // Act
            expected.Name = NEW_NAME;
            await sut.Update(expected);

            // Assert
            var actual = await context.Set<Vehicle>().FindAsync(expected.Id);
            actual.Name.Should().BeEquivalentTo(NEW_NAME);
        }
    }

    [Fact]
    public async Task Update_OnUpdatingNonExistingVehicle_ThrowsDbUpdateConcurrencyException()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owner = EntityFixtures.GenerateOwners(1);
            var vehicleNotInDb = EntityFixtures.GenerateVehicles(1, owner).FirstOrDefault();
            var sut = new BaseRepository<Vehicle>(context);
            // Act
            var act = async () => await sut.Update(vehicleNotInDb);

            // Assert
            await act
                .Should()
                .ThrowAsync<DbUpdateConcurrencyException>();
        }
    }

    #endregion Update

    #region Delete

    [Fact]
    public async Task Delete_OnVehicleInserted_DeleteInsertedVehicle_VehicleIsDeleted()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owner = EntityFixtures.GenerateOwners(1);
            var vehicle = EntityFixtures.GenerateVehicles(1, owner).FirstOrDefault();
            await context.Set<Owner>().AddAsync(owner.FirstOrDefault());
            await context.Set<Vehicle>().AddAsync(vehicle);
            await context.SaveChangesAsync();

            var expected = await context.Set<Vehicle>().FindAsync(vehicle.Id);
            var sut = new BaseRepository<Vehicle>(context);

            // Act
            await sut.Delete(expected.Id);

            // Assert
            var actual = await context.Set<Vehicle>().FindAsync(expected.Id);
            actual.Should().BeNull();
        }
    }

    [Fact]
    public async Task Delete_OnDeletingNonExistingVehicle_ThrowsArgumentNullException()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var owner = EntityFixtures.GenerateOwners(1);
            var vehicleNotInDb = EntityFixtures.GenerateVehicles(1, owner).FirstOrDefault();
            var sut = new BaseRepository<Vehicle>(context);
            // Act
            var act = async () => await sut.Delete(vehicleNotInDb.Id);

            // Assert
            await act
                .Should()
                .ThrowAsync<ArgumentNullException>();
        }
    }

    #endregion Delete
}