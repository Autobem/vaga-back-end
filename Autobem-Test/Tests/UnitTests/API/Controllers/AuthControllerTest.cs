using Domain.Contracts.Service;
using Domain.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq.Protected;
using System.Net;
using Tests.Fixture;
using WebApi.Controllers;

namespace Tests.UnitTests.API.Controllers;

public class AuthControllerTest
{
    private readonly UserLogin USER_LOGIN = new UserLogin()
    {
        Email = "User",
        Password = "password"
    };

    private readonly UserModel USER_MODEL = new UserModel()
    {
        Email = "User",
        Password = "password"
    };

    private readonly HttpResponseMessage OK_HTTP_RESPONSE = new HttpResponseMessage
    {
        StatusCode = HttpStatusCode.OK,
        Content = new StringContent(RESPONSE_CONTENT)
    };

    private readonly HttpResponseMessage BAD_REQUEST_HTTP_RESPONSE = new HttpResponseMessage
    {
        StatusCode = HttpStatusCode.BadRequest,
    };

    private static readonly string RESPONSE_CONTENT = @"
    {
      ""access_token"": ""token"",
      ""expires_in"": 86400,
      ""token_type"": ""Bearer""
    }
    ";

    private readonly string REQUEST_BODY = @"
    {
      ""client_id"": ""id"",
      ""client_secret"": 86400,
      ""audience"": ""Bearer"",
      ""grant_type"": ""credentials"",
    }
    ";

    private readonly string PASSWORD_MATCH = "password";
    private readonly string PASSWORD_NOT_MATCH = "other password";
    private readonly string AUTH0_ENPOINT_PARAMETER = "Auth0:AuthEndpoint";
    private readonly string AUTH0_REQUEST_BODY_PARAMETER = "Auth0:AuthRequestBody";
    private readonly string GOOGLE_URL = "http://google.com";

    [Fact]
    public async Task Login_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(us => us.GetUserLogin(It.IsAny<string>()))
            .ReturnsAsync(USER_MODEL);

        var mockPasswordService = new Mock<IPasswordService>();
        mockPasswordService
            .Setup(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns(PASSWORD_MATCH);

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(OK_HTTP_RESPONSE);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration.Setup(config => config[AUTH0_ENPOINT_PARAMETER]).Returns(GOOGLE_URL);
        mockConfiguration.Setup(config => config[AUTH0_REQUEST_BODY_PARAMETER]).Returns(REQUEST_BODY);
        var sut = new AuthController(mockUserService.Object, mockPasswordService.Object, httpClient, mockConfiguration.Object);

        // Act
        var result = (OkObjectResult)await sut.Login(USER_LOGIN);

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Login_OnSuccess_ShouldReturnUserLoginResponse()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(us => us.GetUserLogin(It.IsAny<string>()))
            .ReturnsAsync(USER_MODEL);

        var mockPasswordService = new Mock<IPasswordService>();
        mockPasswordService
            .Setup(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns(PASSWORD_MATCH);

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(OK_HTTP_RESPONSE);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration.Setup(config => config[AUTH0_ENPOINT_PARAMETER]).Returns(GOOGLE_URL);
        mockConfiguration.Setup(config => config[AUTH0_REQUEST_BODY_PARAMETER]).Returns(REQUEST_BODY);
        var sut = new AuthController(mockUserService.Object, mockPasswordService.Object, httpClient, mockConfiguration.Object);

        // Act
        var result = (OkObjectResult)await sut.Login(USER_LOGIN);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().BeOfType<UserLoginResponse>(); ;
    }

    [Fact]
    public async Task Login_OnCall_InvokeGetUserLoginFromUserService()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(us => us.GetUserLogin(It.IsAny<string>()))
            .ReturnsAsync(USER_MODEL);
        var mockPasswordService = new Mock<IPasswordService>();
        var httpClient = new HttpClient();
        var config = new ConfigurationFixture();
        var sut = new AuthController(mockUserService.Object, mockPasswordService.Object, httpClient, config);

        // Act
        await sut.Login(USER_LOGIN);

        // Assert
        mockUserService.Verify(us => us.GetUserLogin(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task Login_OnUserRetrievedFromService_UserNotFound_ReturnStatusCode404()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(us => us.GetUserLogin(It.IsAny<string>()))
            .Returns(Task.FromResult<UserModel>(null));
        var mockPasswordService = new Mock<IPasswordService>();
        var httpClient = new HttpClient();
        var config = new ConfigurationFixture();
        var sut = new AuthController(mockUserService.Object, mockPasswordService.Object, httpClient, config);

        // Act
        var result = await sut.Login(USER_LOGIN);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
        var objectResult = (NotFoundObjectResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Login_OnUserRetrievedFromService_UserFound_InvokePasswordService()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(us => us.GetUserLogin(It.IsAny<string>()))
            .ReturnsAsync(USER_MODEL);

        var mockPasswordService = new Mock<IPasswordService>();
        mockPasswordService
            .Setup(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns(PASSWORD_MATCH);

        var httpClient = new HttpClient();
        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration.Setup(config => config[AUTH0_ENPOINT_PARAMETER]).Returns(GOOGLE_URL);
        mockConfiguration.Setup(config => config[AUTH0_REQUEST_BODY_PARAMETER]).Returns(REQUEST_BODY);
        var sut = new AuthController(mockUserService.Object, mockPasswordService.Object, httpClient, mockConfiguration.Object);

        // Act
        var result = await sut.Login(USER_LOGIN);

        // Assert
        mockPasswordService.Verify(ps =>
            ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()),
            Times.Once
        );
    }

    [Fact]
    public async Task Login_OnPasswordsNotMatch_ReturnStatusCode404()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(us => us.GetUserLogin(It.IsAny<string>()))
            .ReturnsAsync(USER_MODEL);

        var mockPasswordService = new Mock<IPasswordService>();
        mockPasswordService
            .Setup(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns(PASSWORD_NOT_MATCH);

        var httpClient = new HttpClient();
        var config = new ConfigurationFixture();
        var sut = new AuthController(mockUserService.Object, mockPasswordService.Object, httpClient, config);

        // Act
        var result = await sut.Login(USER_LOGIN);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
        var objectResult = (NotFoundObjectResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Login_OnAuthServerErrorStatusCode_ReturnStatusCore404()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(us => us.GetUserLogin(It.IsAny<string>()))
            .ReturnsAsync(USER_MODEL);

        var mockPasswordService = new Mock<IPasswordService>();
        mockPasswordService
            .Setup(ps => ps.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns(PASSWORD_NOT_MATCH);

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(BAD_REQUEST_HTTP_RESPONSE);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var config = new ConfigurationFixture();
        var sut = new AuthController(mockUserService.Object, mockPasswordService.Object, httpClient, config);

        // Act
        var result = await sut.Login(USER_LOGIN);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
        var objectResult = (NotFoundObjectResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}