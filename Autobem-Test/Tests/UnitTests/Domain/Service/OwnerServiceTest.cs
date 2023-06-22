using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Models;
using Domain.Service;
using Entities.Entities;
using Infrastructure.Helpers;

namespace Tests.UnitTests.Domain.Service;

public class OwnerServiceTest
{
    public class Get
    {
        [Fact]
        public async Task OnSuccess_ReturnOwnerModelsList()
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
        public async Task OnSuccess_InvokeRepository()
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
    }

    public class GetById
    {
        [Fact]
        public async Task OnSuccess_ReturnOwnerModel()
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
        public async Task OnSuccess_InvokeRepository()
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
        public async Task OnSuccess_ReturnTheRightOwner()
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
    }

    public class Insert
    {
        [Fact]
        public async Task OnSuccess_ReturnOwnerModel()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Owner>>();
            mockRepository
                .Setup(repository => repository.Insert(It.IsAny<Owner>()))
                .ReturnsAsync(new Owner());
            var sut = new OwnerService(mockRepository.Object, mapper);

            // Act
            var result = await sut.Insert(new OwnerModel());

            // Assert
            result.Should().BeOfType<OwnerModel>();
        }

        [Fact]
        public async Task OnSuccess_InvokeRepository()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Owner>>();
            mockRepository
                .Setup(repository => repository.Insert(It.IsAny<Owner>()))
                .ReturnsAsync(new Owner());
            var sut = new OwnerService(mockRepository.Object, mapper);

            // Act
            var result = await sut.Insert(new OwnerModel());

            // Assert
            mockRepository.Verify(repo => repo.Insert(It.IsAny<Owner>()), Times.Once);
        }

        [Fact]
        public async Task OnSuccess_ReturnTheRightOwner()
        {
            var expected = new OwnerModel() { Id = Guid.NewGuid() };
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
    }

    public class Update
    {
        [Fact]
        public async Task OnSuccess_InvokeRepository()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Owner>>();
            mockRepository
                .Setup(repository => repository.Update(It.IsAny<Owner>()));
            var sut = new OwnerService(mockRepository.Object, mapper);

            // Act
            await sut.Update(new OwnerModel());

            // Assert
            mockRepository.Verify(repo => repo.Update(It.IsAny<Owner>()));
        }
    }

    public class Delete
    {
        [Fact]
        public async Task OnSuccess_InvokeRepository()
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
    }
}