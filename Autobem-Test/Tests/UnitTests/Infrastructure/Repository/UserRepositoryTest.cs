using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Tests.Fixture;

namespace Tests.UnitTests.Infrastructure.Repository;

public class UserRepositoryTest : IDisposable
{
    private readonly DbContextOptions _options;

    private const int POPULATED_USERS = 10;
    private const int EMPTY_USERS = 0;
    private const string NEW_NAME = "New Name";

    public UserRepositoryTest()
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
            var users = await context.Set<User>().ToListAsync();

            context.Set<User>().RemoveRange(users);
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
            var sut = new BaseRepository<User>(context);

            // Act
            var result = await sut.Get();

            // Assert
            result.Count.Should().Be(EMPTY_USERS);
        }
    }

    [Fact]
    public async Task Get_OnPopulatedDatabase_ReturnAllEntities()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var users = EntityFixtures.GenerateUsers(POPULATED_USERS);
            await context.Set<User>().AddRangeAsync(users);
            await context.SaveChangesAsync();

            var sut = new BaseRepository<User>(context);

            // Act
            var result = await sut.Get();

            // Assert
            result.Count.Should().Be(POPULATED_USERS);
        }
    }

    #endregion Get

    #region GetById

    [Fact]
    public async Task GetById_OnUserNotFound_ReturnNull()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var sut = new BaseRepository<User>(context);

            // Act
            var result = await sut.GetById(new Guid());

            // Assert
            result.Should().Be(null);
        }
    }

    [Fact]
    public async Task GetById_OnUserFound_ReturnUser()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var expected = EntityFixtures.GenerateUsers(1).First();
            await context.Set<User>().AddAsync(expected);
            var sut = new BaseRepository<User>(context);

            // Act
            var actual = await sut.GetById(expected.Id);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }

    #endregion GetById

    #region Insert

    [Fact]
    public async Task Insert_OnUserInserted_CallGetById_ReturnSameUser()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var expected = EntityFixtures.GenerateUsers(1).First();
            var sut = new BaseRepository<User>(context);

            // Act
            await sut.Insert(expected);

            // Assert
            var actual = await context.Set<User>().FindAsync(expected.Id);
            actual.Should().BeEquivalentTo(expected);
        }
    }

    [Fact]
    public async Task Insert_OnUserInserted_ReturnUserInserted()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var expected = EntityFixtures.GenerateUsers(1).First();
            var sut = new BaseRepository<User>(context);

            // Act
            var actual = await sut.Insert(expected);

            // Assert
            actual.Should().BeOfType<User>();
            actual.Should().BeEquivalentTo(expected);
        }
    }

    #endregion Insert

    #region Update

    [Fact]
    public async Task Update_OnUserInserted_UpdateItsName_ReturnUserWithNewName()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var expected = EntityFixtures.GenerateUsers(1).First();
            await context.AddAsync(expected);
            await context.SaveChangesAsync();
            var sut = new BaseRepository<User>(context);

            // Act
            expected.Name = NEW_NAME;
            await sut.Update(expected);

            // Assert
            var actual = await context.Set<User>().FindAsync(expected.Id);
            actual.Name.Should().BeEquivalentTo(NEW_NAME);
        }
    }

    [Fact]
    public async Task Update_OnUpdatingNonExistingUser_ReturnsError()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var notInDbUser = EntityFixtures.GenerateUsers(1).First();
            var sut = new BaseRepository<User>(context);

            // Act
            var act = async () => await sut.Update(notInDbUser);

            // Assert
            await act
                .Should()
                .ThrowAsync<DbUpdateConcurrencyException>();
        }
    }

    #endregion Update

    #region Delete

    [Fact]
    public async Task Delete_OnUserInserted_DeleteInsertedUser_UserIsDeleted()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var expected = EntityFixtures.GenerateUsers(1).First();
            await context.AddAsync(expected);
            await context.SaveChangesAsync();
            var sut = new BaseRepository<User>(context);

            // Act
            await sut.Delete(expected.Id);

            // Assert
            var actual = await context.Set<User>().FindAsync(expected.Id);
            actual.Should().BeNull();
        }
    }

    [Fact]
    public async Task Delete_OnDeletingNonExistingUser_ReturnsError()
    {
        using (var context = new BaseContext(_options))
        {
            // Arrange
            var notInDbUser = EntityFixtures.GenerateUsers(1).First();
            var sut = new BaseRepository<User>(context);

            // Act
            var act = async () => await sut.Delete(new Guid());

            // Assert
            await act
                .Should()
                .ThrowAsync<ArgumentNullException>();
        }
    }

    #endregion Delete
}