using Domain.Contracts.Service;
using Domain.Models;
using Domain.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Tests.UnitTests.API.Controllers;

public class UserControllerTest
{
    #region Get

    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Get())
            .ReturnsAsync(new List<GetUserModel>());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfGetUserModel()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Get())
            .ReturnsAsync(new List<GetUserModel>());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().BeOfType<List<GetUserModel>>();
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeServiceOneTime()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Get())
            .ReturnsAsync(new List<GetUserModel>());
        var sut = new UserController(mockService.Object);

        // Act
        await sut.Get();

        // Assert
        mockService.Verify(service => service.Get(), Times.Once);
    }

    #endregion Get

    #region GetById

    [Fact]
    public async Task GetById_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(new GetUserModel());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (OkObjectResult)await sut.GetById(new Guid());

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetById_OnSuccess_ReturnGetUserModelObject()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(new GetUserModel());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (OkObjectResult)await sut.GetById(new Guid());

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().BeOfType<GetUserModel>();
    }

    [Fact]
    public async Task GetById_OnSuccess_InvokeServiceOneTime()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(new GetUserModel());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (OkObjectResult)await sut.GetById(new Guid());

        // Assert
        mockService.Verify(service => service.GetById(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public async Task GetById_OnSuccess_ReturnGetUserModelObject_WithSameId()
    {
        // Arrange
        var expected = new GetUserModel() { Id = Guid.NewGuid() };
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.GetById(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) => id == expected.Id ? expected : new GetUserModel());

        var sut = new UserController(mockService.Object);

        // Act
        var result = (OkObjectResult)await sut.GetById(expected.Id);

        // Assert
        var actual = (GetUserModel)result.Value!;
        actual.Id.Should().Be(expected.Id);
    }

    [Fact]
    public async Task GetById_OnNotFound_ReturnStatusCode404()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.GetById(It.IsAny<Guid>()))
            .Returns(Task.FromResult<GetUserModel>(null));
        var sut = new UserController(mockService.Object);

        // Act
        var result = await sut.GetById(new Guid());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    #endregion GetById

    #region Insert

    [Fact]
    public async Task Insert_OnSuccess_ReturnStatusCode201()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Insert(It.IsAny<CreateUserModel>()))
            .ReturnsAsync(new GetUserModel());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (CreatedResult)await sut.Insert(new CreateUserModel());

        // Assert
        result.StatusCode.Should().Be(201);
    }

    [Fact]
    public async Task Insert_Insert_OnSuccess_ReturnGetUserModel()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Insert(It.IsAny<CreateUserModel>()))
            .ReturnsAsync(new GetUserModel());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (CreatedResult)await sut.Insert(new CreateUserModel());

        // Assert
        result.Should().BeOfType<CreatedResult>();
        result.Value.Should().BeOfType<GetUserModel>();
    }

    [Fact]
    public async Task Insert_OnSuccess_InvokeServiceOneTime()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Insert(It.IsAny<CreateUserModel>()))
            .ReturnsAsync(new GetUserModel());
        var sut = new UserController(mockService.Object);

        // Act
        var result = (CreatedResult)await sut.Insert(new CreateUserModel());

        // Assert
        mockService.Verify(service => service.Insert(It.IsAny<CreateUserModel>()), Times.Once);
    }

    #endregion Insert

    #region Update

    [Fact]
    public async Task Update_OnSuccess_ReturnStatusCode202()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Update(It.IsAny<UpdateUserModel>()));
        var sut = new UserController(mockService.Object);

        // Act
        var result = (AcceptedResult)await sut.Update(new UpdateUserModel());

        // Assert
        result.StatusCode.Should().Be(202);
    }

    [Fact]
    public async Task Update_OnSuccess_InvokedServiceOneTime()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Update(It.IsAny<UpdateUserModel>()));
        var sut = new UserController(mockService.Object);

        // Act
        var result = (AcceptedResult)await sut.Update(new UpdateUserModel());

        // Assert
        mockService.Verify(service => service.Update(It.IsAny<UpdateUserModel>()), Times.Once);
    }

    #endregion Update

    #region Delete

    [Fact]
    public async Task Delete_OnSuccess_ReturnStatusCode202()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Delete(It.IsAny<Guid>()));
        var sut = new UserController(mockService.Object);

        // Act
        var result = (AcceptedResult)await sut.Delete(new Guid());

        // Assert
        result.StatusCode.Should().Be(202);
    }

    [Fact]
    public async Task Delete_OnSuccess_ShouldInvokeServiceOneTime()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(service => service.Delete(It.IsAny<Guid>()));
        var sut = new UserController(mockService.Object);

        // Act
        var result = (AcceptedResult)await sut.Delete(new Guid());

        // Assert
        mockService.Verify(service => service.Delete(It.IsAny<Guid>()), Times.Once);
    }

    #endregion Delete
}