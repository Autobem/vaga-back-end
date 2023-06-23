using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Tests.Fixture;

namespace Tests.UnitTests.Infrastructure.Repository;

public class VehicleRepositoryTest
{
    private const int POPULATED_VEHICLES = 10;
    private const int EMPTY_VEHICLES = 0;
    private const string NEW_NAME = "New Name";

    [Collection("Repository Unit Tests")]
    public class Get : IDisposable
    {
        private readonly DbContextOptions _options;

        public Get()
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

        [Fact]
        public async Task OnEmptyDatabase_ReturnEmptyList()
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
        public async Task OnPopulatedDatabase_ReturnAllEntities()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owners = OwnerFixture.GenerateOwners(POPULATED_VEHICLES);
                await context.Set<Owner>().AddRangeAsync(owners);
                await context.SaveChangesAsync();

                var vehicles = VehicleFixture.GenerateVehicles(POPULATED_VEHICLES, owners);
                await context.Set<Vehicle>().AddRangeAsync(vehicles);
                await context.SaveChangesAsync();

                var sut = new BaseRepository<Vehicle>(context);

                // Act
                var result = await sut.Get();

                // Assert
                result.Count.Should().Be(POPULATED_VEHICLES);
            }
        }
    }

    [Collection("Repository Unit Tests")]
    public class GetById : IDisposable
    {
        private readonly DbContextOptions _options;

        public GetById()
        {
            _options = new DbContextOptionsBuilder<BaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
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

        [Fact]
        public async Task OnVehicleNotFound_ReturnNull()
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
        public async Task OnOwnerFound_ReturnOwner()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owner = OwnerFixture.GenerateOwners(1);
                var expected = VehicleFixture.GenerateVehicles(1, owner).FirstOrDefault();
                await context.Set<Owner>().AddAsync(owner.FirstOrDefault());
                await context.Set<Vehicle>().AddAsync(expected);
                var sut = new BaseRepository<Vehicle>(context);

                // Act
                var actual = await sut.GetById(expected.Id);

                // Assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }

    [Collection("Repository Unit Tests")]
    public class Insert : IDisposable
    {
        private readonly DbContextOptions _options;

        public Insert()
        {
            _options = new DbContextOptionsBuilder<BaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        public async void Dispose()
        {
            using (var context = new BaseContext(_options))
            {
                var owners = await context.Set<Owner>().ToListAsync();
                var vehicle = await context.Set<Vehicle>().ToListAsync();
                context.Set<Owner>().RemoveRange(owners);
                context.Set<Vehicle>().RemoveRange(vehicle);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnVehicleInserted_CallGetById_ReturnSameOwner()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owner = OwnerFixture.GenerateOwners(1);
                var expected = VehicleFixture.GenerateVehicles(1, owner).FirstOrDefault();
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
        public async Task OnVehicleInserted_ReturnVehicleInserted()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owner = OwnerFixture.GenerateOwners(1);
                var expected = VehicleFixture.GenerateVehicles(1, owner).First();
                var sut = new BaseRepository<Vehicle>(context);

                // Act
                var actual = await sut.Insert(expected);

                // Assert
                actual.Should().BeOfType<Vehicle>();
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }

    [Collection("Repository Unit Tests")]
    public class Update : IDisposable
    {
        private readonly DbContextOptions _options;

        public Update()
        {
            _options = new DbContextOptionsBuilder<BaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        public async void Dispose()
        {
            using (var context = new BaseContext(_options))
            {
                var owners = await context.Set<Owner>().ToListAsync();
                var vehicle = await context.Set<Vehicle>().ToListAsync();
                context.Set<Owner>().RemoveRange(owners);
                context.Set<Vehicle>().RemoveRange(vehicle);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnVehicleInserted_UpdateItsName_ReturnVehicleWithNewName()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owner = OwnerFixture.GenerateOwners(1);
                var expected = VehicleFixture.GenerateVehicles(1, owner).FirstOrDefault();
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
        public async Task OnUpdatingNonExistingVehicle_ThrowsDbUpdateConcurrencyException()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owner = OwnerFixture.GenerateOwners(1);
                var vehicleNotInDb = VehicleFixture.GenerateVehicles(1, owner).FirstOrDefault();
                var sut = new BaseRepository<Vehicle>(context);
                // Act
                var act = async () => await sut.Update(vehicleNotInDb);

                // Assert
                await act
                    .Should()
                    .ThrowAsync<DbUpdateConcurrencyException>();
            }
        }
    }

    [Collection("Repository Unit Tests")]
    public class Delete : IDisposable
    {
        private readonly DbContextOptions _options;

        public Delete()
        {
            _options = new DbContextOptionsBuilder<BaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        public async void Dispose()
        {
            using (var context = new BaseContext(_options))
            {
                var owners = await context.Set<Owner>().ToListAsync();
                var vehicle = await context.Set<Vehicle>().ToListAsync();
                context.Set<Owner>().RemoveRange(owners);
                context.Set<Vehicle>().RemoveRange(vehicle);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnVehicleInserted_DeleteInsertedVehicle_VehicleIsDeleted()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owner = OwnerFixture.GenerateOwners(1);
                var vehicle = VehicleFixture.GenerateVehicles(1, owner).FirstOrDefault();
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
        public async Task OnDeletingNonExistingVehicle_ThrowsArgumentNullException()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owner = OwnerFixture.GenerateOwners(1);
                var vehicleNotInDb = VehicleFixture.GenerateVehicles(1, owner).FirstOrDefault();
                var sut = new BaseRepository<Vehicle>(context);
                // Act
                var act = async () => await sut.Delete(vehicleNotInDb.Id);

                // Assert
                await act
                    .Should()
                    .ThrowAsync<ArgumentNullException>();
            }
        }
    }
}