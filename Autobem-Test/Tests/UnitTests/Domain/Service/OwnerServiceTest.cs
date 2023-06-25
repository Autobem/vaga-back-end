using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Models;
using Domain.Service;
using Entities.Entities;
using FluentValidation;
using Infrastructure.Helpers;

namespace Tests.UnitTests.Domain.Service;

public class OwnerServiceTest
{
    private static OwnerModel VALID_OWNER_MODEL = new OwnerModel()
    {
        Id = Guid.NewGuid(),
        Name = new string('a', 8),
        Cpf = new string('0', 11),
        CNH = new string('0', 11),
        Phone = new string('0', 11),
        Email = "email@email.com",
        BirthDate = DateTime.Now,
    };

    private static OwnerModel INVALID_OWNER_MODEL = new OwnerModel()
    {
        Id = new Guid()
    };

    #region Get

    [Fact]
    public async Task Get_OnSuccess_ReturnOwnerModelsList()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Get())
                .ReturnsAsync(new List<Owner>());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<List<OwnerModel>>();
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeRepository()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Get())
                .ReturnsAsync(new List<Owner>());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        await sut.Get();

        // Assert
        mockRepository.Verify(repo => repo.Get(), Times.Once);
    }

    #endregion Get

    #region GetById

    [Fact]
    public async Task GetById_OnSuccess_ReturnOwnerModel()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.GetById(new Guid()))
                .ReturnsAsync(new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        var result = await sut.GetById(new Guid());

        // Assert
        result.Should().BeOfType<OwnerModel>();
    }

    [Fact]
    public async Task GetById_OnSuccess_InvokeRepository()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.GetById(new Guid()))
                .ReturnsAsync(new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        var result = await sut.GetById(new Guid());

        // Assert
        mockRepository.Verify(repo => repo.GetById(new Guid()), Times.Once);
    }

    [Fact]
    public async Task GetById_OnSuccess_ReturnTheRightOwner()
    {
        var expected = new Owner() { Id = Guid.NewGuid() };

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.GetById(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) => id == expected.Id ? expected : new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Acts
        var actual = await sut.GetById(expected.Id);

        // Assert
        actual.Id.Should().Be(expected.Id);
    }

    #endregion GetById

    #region Insert

    [Fact]
    public async Task Insert_OnValidOwnerModel_ReturnOwnerModel()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<Owner>()))
            .ReturnsAsync(new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        var result = await sut.Insert(VALID_OWNER_MODEL);

        // Assert
        result.Should().BeOfType<OwnerModel>();
    }

    [Fact]
    public async Task Insert_OnValidOwnerModel_InvokeRepository()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<Owner>()))
            .ReturnsAsync(new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        var result = await sut.Insert(VALID_OWNER_MODEL);

        // Assert
        mockRepository.Verify(repo => repo.Insert(It.IsAny<Owner>()), Times.Once);
    }

    [Fact]
    public async Task Insert_OnSuccess_ReturnTheRightOwner()
    {
        var expected = VALID_OWNER_MODEL;
        var aux = new Owner() { Id = expected.Id };
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<Owner>()))
            .ReturnsAsync((Owner on) => on.Id == aux.Id ? aux : new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Acts
        var actual = await sut.Insert(expected);

        // Assert
        actual.Id.Should().Be(expected.Id);
    }

    [Fact]
    public async Task Insert_OnValidOwnerModel_InvokeRepository_LastChangeAndCreatedDateNotNull()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<Owner>()))
            .ReturnsAsync(new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Acts
        await sut.Insert(VALID_OWNER_MODEL);

        // Assert
        mockRepository.Verify(repo => repo.Insert(
            It.Is<Owner>(o =>
                o.InclusionDate != DateTime.MinValue &&
                o.LastChange != DateTime.MinValue
        )));
    }

    [Fact]
    public async Task Insert_OnInvalidOwnerModel_ThrowsValidationException()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Insert(It.IsAny<Owner>()))
            .ReturnsAsync(new Owner());
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Acts
        var act = async () => await sut.Insert(INVALID_OWNER_MODEL);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    #endregion Insert

    #region Update

    [Fact]
    public async Task Update_OnValidOwnerModel_InvokeRepositoryUpdateMethod()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Update(It.IsAny<Owner>()));
        var mockOwner = new Mock<Owner>();
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        await sut.Update(VALID_OWNER_MODEL);

        // Assert
        mockRepository.Verify(repo => repo.Update(It.IsAny<Owner>()));
    }

    [Fact]
    public async Task Update_OnInvalidValidOwnerModel_ThrowsValidationException()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Update(It.IsAny<Owner>()));

        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        var act = async () => await sut.Update(INVALID_OWNER_MODEL);

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
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        var mapper = new Mapper(configuration);

        var mockRepository = new Mock<IBaseRepository<Owner>>();
        mockRepository
            .Setup(repository => repository.Delete(It.IsAny<Guid>()));
        var sut = new OwnerService(mockRepository.Object, mapper);

        // Act
        await sut.Delete(new Guid());

        // Assert
        mockRepository.Verify(repo => repo.Delete(It.IsAny<Guid>()));
    }

    #endregion Delete
}