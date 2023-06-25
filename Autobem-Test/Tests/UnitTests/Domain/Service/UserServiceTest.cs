using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Models;
using Domain.Models.UserModels;
using Domain.Service;
using Entities.Entities;
using Entities.Enums;
using FluentValidation;
using Infrastructure.Helpers;
using Tests.Fixture;

namespace Tests.UnitTests.Domain.Service;

public class UserServiceTest
{
    private static CreateUserModel VALID_CREATE_USER_MODEL = new CreateUserModel()
    {
        Id = Guid.NewGuid(),
        Name = new string('a', 8),
        Password = "aaaaaaaA1",
        PasswordConfirm = "aaaaaaaA1",
        Email = "email@email.com",
    };

    private static CreateUserModel INVALID_CREATE_USER_MODEL = new CreateUserModel()
    {
        Id = new Guid()
    };

    private static UpdateUserModel VALID_UPDATE_USER_MODEL = new UpdateUserModel()
    {
        Id = Guid.NewGuid(),
        Name = new string('a', 8),
        Email = "email@email.com",
        Status = StatusEnum.ACTIVE
    };

    private static UpdateUserModel INVALID_UPDATE_USER_MODEL = new UpdateUserModel()
    {
        Id = new Guid()
    };

    private static User USER_WITH_PASSWORD_AND_SALT = new User()
    {
        Id = Guid.NewGuid(),
        Name = new string('a', 8),
        Email = "email@email.com",
        Status = StatusEnum.ACTIVE,
        Password = "password",
        PasswordSalt = "salt"
    };

    #region Get

    [Fact]
    public async Task Get_OnSuccess_ReturnGetUserModelList()

    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());
        mockRepository
            .Setup(repository => repository.Get())
            .ReturnsAsync(new List<User>());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<List<GetUserModel>>();
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeRepository()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());
        mockRepository
            .Setup(repository => repository.Get())
            .ReturnsAsync(new List<User>());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);
        // Act
        await sut.Get();

        // Assert
        mockRepository.Verify(repo => repo.Get(), Times.Once);
    }

    #endregion Get

    #region GetById

    [Fact]
    public async Task GetById_OnSuccess_ReturnGetUserModel()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.GetById(new Guid()))
            .ReturnsAsync(new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var result = await sut.GetById(new Guid());

        // Assert
        result.Should().BeOfType<GetUserModel>();
    }

    [Fact]
    public async Task GetById_OnSuccess_InvokeRepository()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.GetById(new Guid()))
            .ReturnsAsync(new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var result = await sut.GetById(new Guid());

        // Assert
        mockRepository.Verify(repo => repo.GetById(new Guid()), Times.Once);
    }

    [Fact]
    public async Task GetById_OnSuccess_ReturnTheRightUser()
    {
        var expected = new User() { Id = Guid.NewGuid() };

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.GetById(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) => id == expected.Id ? expected : new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Acts
        var actual = await sut.GetById(expected.Id);

        // Assert
        actual.Id.Should().Be(expected.Id);
    }

    #endregion GetById

    #region Insert

    [Fact]
    public async Task Insert_OnValidCreateUserModel_ReturnGetUserModel()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<User>()))
            .ReturnsAsync(new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var result = await sut.Insert(VALID_CREATE_USER_MODEL);

        // Assert
        result.Should().BeOfType<GetUserModel>();
    }

    [Fact]
    public async Task Insert_OnValidCreateUserModel_InvokeRepository()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<User>()))
            .ReturnsAsync(new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var result = await sut.Insert(VALID_CREATE_USER_MODEL);

        // Assert
        mockRepository.Verify(repo => repo.Insert(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task Insert_OnValidCreateUserModel_ReturnTheRightUser()
    {
        // Arrange
        var expected = VALID_CREATE_USER_MODEL;
        var aux = new User() { Id = expected.Id };
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<User>()))
            .ReturnsAsync((User on) => on.Id == aux.Id ? aux : new User());
        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var actual = await sut.Insert(expected);

        // Assert
        actual.Id.Should().Be(expected.Id);
    }

    [Fact]
    public async Task Insert_OnValidCreateUserModel_InvokePasswordService_CallGenerateSalt()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<User>()))
            .ReturnsAsync(new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());
        mockPasswordService
            .Setup(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns("");
        mockPasswordService
            .Setup(ps => ps.GenerateSalt())
            .Returns("");

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        await sut.Insert(VALID_CREATE_USER_MODEL);

        // Assert
        mockPasswordService.Verify(ps => ps.GenerateSalt(), Times.Once);
    }

    [Fact]
    public async Task Insert_OnValidCreateUserModel_InvokePasswordService_CallHashPassword()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<User>()))
            .ReturnsAsync(new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());
        mockPasswordService
            .Setup(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns("");
        mockPasswordService
            .Setup(ps => ps.GenerateSalt())
            .Returns("");

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        await sut.Insert(VALID_CREATE_USER_MODEL);

        // Assert
        mockPasswordService.Verify(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task Insert_OnInvalidCreateUserModel_ThrowsValidationException()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<User>()))
            .ReturnsAsync(new User());

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var act = async () => await sut.Insert(INVALID_CREATE_USER_MODEL);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    #endregion Insert

    #region Update

    [Fact]
    public async Task Update_OnValidUpdateUserModel_InvokeRepositoryUpdateMethod()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Update(It.IsAny<User>()));
        mockRepository
            .Setup(repository => repository.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(USER_WITH_PASSWORD_AND_SALT);
        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        await sut.Update(VALID_UPDATE_USER_MODEL);

        // Assert
        mockRepository.Verify(repo => repo.Update(It.IsAny<User>()));
    }

    [Fact]
    public async Task Update_OnValidUpdateUserModel_FetchTheUserPassword_ShouldUpdateUserWithThePasswordFromFetchedUser()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Update(It.IsAny<User>()));
        mockRepository
            .Setup(repository => repository.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(USER_WITH_PASSWORD_AND_SALT);

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        await sut.Update(VALID_UPDATE_USER_MODEL);

        // Assert
        mockRepository.Verify(repo =>
            repo.Update(It.Is<User>(u =>
                u.Password == USER_WITH_PASSWORD_AND_SALT.Password &&
                u.PasswordSalt == USER_WITH_PASSWORD_AND_SALT.PasswordSalt
            )));
    }

    [Fact]
    public async Task Update_OnInvalidValidUpdateUserModel_ThrowsValidationException()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Update(It.IsAny<User>()));

        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        var act = async () => await sut.Update(INVALID_UPDATE_USER_MODEL);

        // Assert
        await act
            .Should()
            .ThrowAsync<ValidationException>();
    }

    #endregion Update

    #region Delete

    [Fact]
    public async Task Delete_OnSuccess_InvokeRepository()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<User>>();
        mockRepository
            .Setup(repository => repository.Delete(It.IsAny<Guid>()));
        var mockPasswordService = new Mock<PasswordService>(new ConfigurationFixture());

        var sut = new UserService(mockRepository.Object, mockPasswordService.Object, mapper);

        // Act
        await sut.Delete(new Guid());

        // Assert
        mockRepository.Verify(repo => repo.Delete(It.IsAny<Guid>()));
    }

    #endregion Delete
}