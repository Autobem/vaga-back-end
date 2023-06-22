﻿using Domain.Contracts.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Tests.UnitTests.API.Controllers;

public class VehicleControllerTest
{
    public class Get
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Get())
                .ReturnsAsync(new List<VehicleModel>());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task OnSuccess_ReturnListOfVehicles()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Get())
                .ReturnsAsync(new List<VehicleModel>());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().BeOfType<List<VehicleModel>>();
        }

        [Fact]
        public async Task OnSuccess_InvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Get())
                .ReturnsAsync(new List<VehicleModel>());
            var sut = new VehicleController(mockService.Object);

            // Act
            await sut.Get();

            // Assert
            mockService.Verify(service => service.Get(), Times.Once);
        }
    }

    public class GetById
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new VehicleModel());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(new Guid());

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task OnSuccess_ReturnVehicleModelObject()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new VehicleModel());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(new Guid());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().BeOfType<VehicleModel>();
        }

        [Fact]
        public async Task OnSuccess_InvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new VehicleModel());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(new Guid());

            // Assert
            mockService.Verify(service => service.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task OnSuccess_ReturnVehicleModelObject_WithSameId()
        {
            // Arrange
            var expected = new VehicleModel() { Id = Guid.NewGuid() };
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => id == expected.Id ? expected : new VehicleModel());

            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(expected.Id);

            // Assert
            var actual = (VehicleModel)result.Value!;
            actual.Id.Should().Be(expected.Id);
        }

        [Fact]
        public async Task OnNotFound_ReturnStatusCode404()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .Returns(Task.FromResult<VehicleModel>(null));
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = await sut.GetById(new Guid());

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }

    public class Insert
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode201()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Insert(It.IsAny<VehicleModel>()))
                .ReturnsAsync(new VehicleModel());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (CreatedResult)await sut.Insert(new VehicleModel());

            // Assert
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task OnSuccess_ReturnVehicle()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Insert(It.IsAny<VehicleModel>()))
                .ReturnsAsync(new VehicleModel());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (CreatedResult)await sut.Insert(new VehicleModel());

            // Assert
            result.Should().BeOfType<CreatedResult>();
            result.Value.Should().BeOfType<VehicleModel>();
        }

        [Fact]
        public async Task OnSuccess_InvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Insert(It.IsAny<VehicleModel>()))
                .ReturnsAsync(new VehicleModel());
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (CreatedResult)await sut.Insert(new VehicleModel());

            // Assert
            mockService.Verify(service => service.Insert(It.IsAny<VehicleModel>()), Times.Once);
        }
    }

    public class Update
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode202()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Update(It.IsAny<VehicleModel>()));
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Update(new VehicleModel());

            // Assert
            result.StatusCode.Should().Be(202);
        }

        [Fact]
        public async Task OnSuccess_InvokedServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Update(It.IsAny<VehicleModel>()));
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Update(new VehicleModel());

            // Assert
            mockService.Verify(service => service.Update(It.IsAny<VehicleModel>()), Times.Once);
        }
    }
    public class Delete
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode202()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Delete(It.IsAny<Guid>()));
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Delete(new Guid());

            // Assert
            result.StatusCode.Should().Be(202);
        }

        [Fact]
        public async Task OnSuccess_ShouldInvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.Delete(It.IsAny<Guid>()));
            var sut = new VehicleController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Delete(new Guid());

            // Assert
            mockService.Verify(service => service.Delete(It.IsAny<Guid>()), Times.Once);
        }
    }
}