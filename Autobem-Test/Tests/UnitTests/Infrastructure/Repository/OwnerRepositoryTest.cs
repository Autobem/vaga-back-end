using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Tests.Fixture;

namespace Tests.UnitTests.Infrastructure.Repository;

public class OwnerRepositoryTest
{
    private const int POPULATED_OWNERS = 10;
    private const int EMPTY_OWNERS = 0;
    private const string NEW_NAME = "New Name";

    [Collection("Owner Repository Unit Tests")]
    public class Get : IDisposable
    {
        private readonly DbContextOptions _options;

        public Get()
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
                context.Set<Owner>().RemoveRange(owners);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnEmptyDatabase_ReturnEmptyList()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var sut = new BaseRepository<Owner>(context);

                // Act
                var result = await sut.Get();

                // Assert
                result.Count.Should().Be(EMPTY_OWNERS);
            }
        }

        [Fact]
        public async Task OnPopulatedDatabase_ReturnAllEntities()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var owners = OwnerFixture.GenerateOwners(POPULATED_OWNERS);
                await context.Set<Owner>().AddRangeAsync(owners);
                await context.SaveChangesAsync();

                var sut = new BaseRepository<Owner>(context);

                // Act
                var result = await sut.Get();

                // Assert
                result.Count.Should().Be(POPULATED_OWNERS);
            }
        }
    }

    [Collection("Owner Repository Unit Tests")]
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
                context.Set<Owner>().RemoveRange(owners);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnOwnerNotFound_ReturnNull()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var sut = new BaseRepository<Owner>(context);

                // Act
                var result = await sut.GetById(new Guid());

                // Assert
                result.Should().Be(null);
            }
        }

        [Fact]
        public async Task OnOwnerFound_ReturnOwner()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var expected = OwnerFixture.GenerateOwners(1).First();
                await context.Set<Owner>().AddAsync(expected);
                var sut = new BaseRepository<Owner>(context);

                // Act
                var actual = await sut.GetById(expected.Id);

                // Assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }

    [Collection("Owner Repository Unit Tests")]
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
                context.Set<Owner>().RemoveRange(owners);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnOwnerInserted_CallGetById_ReturnSameOwner()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var expected = OwnerFixture.GenerateOwners(1).First();
                var sut = new BaseRepository<Owner>(context);

                // Act
                await sut.Insert(expected);

                // Assert
                var actual = await context.Set<Owner>().FindAsync(expected.Id);
                actual.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public async Task OnOwnerInserted_ReturnOwnerInserted()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var expected = OwnerFixture.GenerateOwners(1).First();
                var sut = new BaseRepository<Owner>(context);

                // Act
                var actual = await sut.Insert(expected);

                // Assert
                actual.Should().BeOfType<Owner>();
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }

    [Collection("Owner Repository Unit Tests")]
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
                context.Set<Owner>().RemoveRange(owners);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnOwnerInserted_UpdateItsName_ReturnOwnerWithNewName()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var expected = OwnerFixture.GenerateOwners(1).First();
                await context.AddAsync(expected);
                await context.SaveChangesAsync();
                var sut = new BaseRepository<Owner>(context);

                // Act
                expected.Name = NEW_NAME;
                await sut.Update(expected);

                // Assert
                var actual = await context.Set<Owner>().FindAsync(expected.Id);
                actual.Name.Should().BeEquivalentTo(NEW_NAME);
            }
        }

        [Fact]
        public async Task OnUpdatingNonExistingOwner_ReturnsError()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var notInDbOwner = OwnerFixture.GenerateOwners(1).First();
                var sut = new BaseRepository<Owner>(context);

                // Act
                var act = async () => await sut.Update(notInDbOwner);

                // Assert
                await act
                    .Should()
                    .ThrowAsync<DbUpdateConcurrencyException>();
            }
        }
    }
    
    [Collection("Owner Repository Unit Tests")]
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
                context.Set<Owner>().RemoveRange(owners);
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task OnOwnerInserted_DeleteInsertedOwner_OwnerIsDeleted()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var expected = OwnerFixture.GenerateOwners(1).First();
                await context.AddAsync(expected);
                await context.SaveChangesAsync();
                var sut = new BaseRepository<Owner>(context);

                // Act
                await sut.Delete(expected.Id);

                // Assert
                var actual = await context.Set<Owner>().FindAsync(expected.Id);
                actual.Should().BeNull();
            }
        }

        [Fact]
        public async Task OnDeletingNonExistingOwner_ReturnsError()
        {
            using (var context = new BaseContext(_options))
            {
                // Arrange
                var notInDbOwner = OwnerFixture.GenerateOwners(1).First();
                var sut = new BaseRepository<Owner>(context);

                // Act
                var act = async () => await sut.Delete(new Guid());

                // Assert
                await act
                    .Should()
                    .ThrowAsync<ArgumentNullException>();
            }
        }
    }
}