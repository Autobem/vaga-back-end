﻿using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Models;
using Domain.Service;
using Entities.Entities;
using FluentValidation;
using Infrastructure.Helpers;

namespace Tests.UnitTests.Domain.Service;

public class VehicleServiceTest
{
    private static VehicleModel VALID_VEHICLE_MODEL = new VehicleModel()
    {
        Id = Guid.NewGuid(),
        Name = "UNO",
        Plate = "ABC-1234",
        Brand = "FIAT",
        City = "RECIFE",
        Color = "RED",
        State = "PE",
        Year = "2005",
        OwnerId = Guid.NewGuid(),
    };

    private static VehicleModel INVALID_VEHICLE_MODEL = new VehicleModel()
    {
        Id = new Guid(),
    };

    public class Get
    {
        [Fact]
        public async Task OnSuccess_ReturnVehicleModelsList()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Get())
                .ReturnsAsync(new List<Vehicle>());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            var result = await sut.Get();

            // Assert
            result.Should().BeOfType<List<VehicleModel>>();
        }

        [Fact]
        public async Task OnSuccess_InvokeRepository()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Get())
                .ReturnsAsync(new List<Vehicle>());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            await sut.Get();

            // Assert
            mockRepository.Verify(repo => repo.Get(), Times.Once);
        }
    }

    public class GetById
    {
        [Fact]
        public async Task OnSuccess_ReturnVehicleModel()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.GetById(new Guid()))
                .ReturnsAsync(new Vehicle());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            var result = await sut.GetById(new Guid());

            // Assert
            result.Should().BeOfType<VehicleModel>();
        }

        [Fact]
        public async Task OnSuccess_InvokeRepository()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.GetById(new Guid()))
                    .ReturnsAsync(new Vehicle());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            var result = await sut.GetById(new Guid());

            // Assert
            mockRepository.Verify(repo => repo.GetById(new Guid()), Times.Once);
        }

        [Fact]
        public async Task OnSuccess_ReturnTheRightVehicle()
        {
            var expected = new Vehicle() { Id = Guid.NewGuid() };

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => id == expected.Id ? expected : new Vehicle());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Acts
            var actual = await sut.GetById(expected.Id);

            // Assert
            actual.Id.Should().Be(expected.Id);
        }
    }

    public class Insert
    {
        [Fact]
        public async Task OnValidVehicleModel_ReturnVehicleModel()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Insert(It.IsAny<Vehicle>()))
                .ReturnsAsync(new Vehicle());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            var result = await sut.Insert(VALID_VEHICLE_MODEL);

            // Assert
            result.Should().BeOfType<VehicleModel>();
        }

        [Fact]
        public async Task OnValidVehicleModel_InvokeRepository()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Insert(It.IsAny<Vehicle>()))
                .ReturnsAsync(new Vehicle());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            var result = await sut.Insert(VALID_VEHICLE_MODEL);

            // Assert
            mockRepository.Verify(repo => repo.Insert(It.IsAny<Vehicle>()), Times.Once);
        }

        [Fact]
        public async Task OnValidVehicleModel_ReturnTheRightVehicle()
        {
            var expected = VALID_VEHICLE_MODEL;
            var aux = new Vehicle() { Id = expected.Id };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Insert(It.IsAny<Vehicle>()))
                .ReturnsAsync((Vehicle on) => on.Id == aux.Id ? aux : new Vehicle());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Acts
            var actual = await sut.Insert(expected);

            // Assert
            actual.Id.Should().Be(expected.Id);
        }

        [Fact]
        public async Task OnInvalidVehicleModel_ThrowsValidationException()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Insert(It.IsAny<Vehicle>()))
                .ReturnsAsync(new Vehicle());
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            var act = async () => await sut.Insert(INVALID_VEHICLE_MODEL);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }
    }

    public class Update
    {
        [Fact]
        public async Task OnValidVehicleModel_InvokeRepository()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Update(It.IsAny<Vehicle>()));
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            await sut.Update(VALID_VEHICLE_MODEL);

            // Assert
            mockRepository.Verify(repo => repo.Update(It.IsAny<Vehicle>()));
        }

        [Fact]
        public async Task OnInvalidVehicleModel_ThrowsValidationException()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Update(It.IsAny<Vehicle>()));
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            var act = async () => await sut.Update(INVALID_VEHICLE_MODEL);

            // Assert
            await act
                .Should()
                .ThrowAsync<ValidationException>();
        }
    }

    public class Delete
    {
        [Fact]
        public async Task OnSuccess_InvokeRepository()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = new Mapper(configuration);

            var mockRepository = new Mock<IBaseRepository<Vehicle>>();
            mockRepository
                .Setup(repository => repository.Delete(It.IsAny<Guid>()));
            var sut = new VehicleService(mockRepository.Object, mapper);

            // Act
            await sut.Delete(new Guid());

            // Assert
            mockRepository.Verify(repo => repo.Delete(It.IsAny<Guid>()));
        }
    }
}