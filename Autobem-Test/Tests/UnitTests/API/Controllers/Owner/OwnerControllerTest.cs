using Domain.Contracts.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Tests.UnitTests.API.Controllers.Owner;

public class OwnerControllerTest
{
    public class Get
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Get())
                .ReturnsAsync(new List<OwnerModel>());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task OnSuccess_ReturnListOfOwners()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Get())
                .ReturnsAsync(new List<OwnerModel>());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().BeOfType<List<OwnerModel>>();
        }

        [Fact]
        public async Task OnSuccess_InvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Get())
                .ReturnsAsync(new List<OwnerModel>());
            var sut = new OwnerController(mockService.Object);

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
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new OwnerModel());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(new Guid());

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task OnSuccess_ReturnOnwerModelObject()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new OwnerModel());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(new Guid());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().BeOfType<OwnerModel>();
        }

        [Fact]
        public async Task OnSuccess_InvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new OwnerModel());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(new Guid());

            // Assert
            mockService.Verify(service => service.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task OnSuccess_ReturnOnwerModelObject_WithSameId()
        {
            // Arrange
            var expected = new OwnerModel() { Id = Guid.NewGuid() };
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => id == expected.Id ? expected : new OwnerModel());

            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetById(expected.Id);

            // Assert
            var actual = (OwnerModel)result.Value!;
            actual.Id.Should().Be(expected.Id);
        }

        [Fact]
        public async Task OnNotFound_ReturnStatusCode404()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .Returns(Task.FromResult<OwnerModel>(null));
            var sut = new OwnerController(mockService.Object);

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
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Insert(It.IsAny<OwnerModel>()))
                .ReturnsAsync(new OwnerModel());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (CreatedResult)await sut.Insert(new OwnerModel());

            // Assert
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task OnSuccess_ReturnOwner()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Insert(It.IsAny<OwnerModel>()))
                .ReturnsAsync(new OwnerModel());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (CreatedResult)await sut.Insert(new OwnerModel());

            // Assert
            result.Should().BeOfType<CreatedResult>();
            result.Value.Should().BeOfType<OwnerModel>();
        }

        [Fact]
        public async Task OnSuccess_InvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Insert(It.IsAny<OwnerModel>()))
                .ReturnsAsync(new OwnerModel());
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (CreatedResult)await sut.Insert(new OwnerModel());

            // Assert
            mockService.Verify(service => service.Insert(It.IsAny<OwnerModel>()), Times.Once);
        }
    }

    public class Update
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode202()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Update(It.IsAny<OwnerModel>()));
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Update(new OwnerModel());

            // Assert
            result.StatusCode.Should().Be(202);
        }

        [Fact]
        public async Task OnSuccess_InvokedServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Update(It.IsAny<OwnerModel>()));
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Update(new OwnerModel());

            // Assert
            mockService.Verify(service => service.Update(It.IsAny<OwnerModel>()), Times.Once);
        }
    }

    public class Delete
    {
        [Fact]
        public async Task OnSuccess_ReturnStatusCode202()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Delete(It.IsAny<Guid>()));
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Delete(new Guid());

            // Assert
            result.StatusCode.Should().Be(202);
        }

        [Fact]
        public async Task OnSuccess_ShouldInvokeServiceOneTime()
        {
            // Arrange
            var mockService = new Mock<IOwnerService>();
            mockService
                .Setup(service => service.Delete(It.IsAny<Guid>()));
            var sut = new OwnerController(mockService.Object);

            // Act
            var result = (AcceptedResult)await sut.Delete(new Guid());

            // Assert
            mockService.Verify(service => service.Delete(It.IsAny<Guid>()), Times.Once);
        }
    }
}