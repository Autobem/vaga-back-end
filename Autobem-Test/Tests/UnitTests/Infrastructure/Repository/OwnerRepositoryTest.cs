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
}