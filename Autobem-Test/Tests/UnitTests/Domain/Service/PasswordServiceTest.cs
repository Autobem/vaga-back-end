﻿using Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Tests.Fixture;

namespace Tests.UnitTests.Domain.Service;

public class PasswordServiceTest
{
    private const string PASSWORD = "password";
    private const string SALT = "salt";
    private const int ZERO_ITERATIONS = 0;
    private const int TWO_ITERATIONS = 2;
    private const int THREE_ITERATIONS = 3;




    #region HashPassword

    [Fact]
    public void HashPassword_OnOnlyPassingPassword_ReturnString()
    {
        // Arrange
        var sut = new PasswordService(new ConfigurationFixture());

        // Act
        var result = sut.HashPassword(PASSWORD);

        // Assert
        result.Should().BeOfType<string>();
    }

    [Fact]
    public void HashPassword_OnOnlyPassingPassword_ReturnStringMustBeDifferentFromPassword()
    {
        // Arrange
        var mockService = new Mock<PasswordService>(new ConfigurationFixture());
        mockService
            .Setup(p => p.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .CallBase();
        mockService
            .Setup(p => p.GenerateSalt())
            .CallBase();
        var sut = mockService.Object;

        // Act
        var result = sut.HashPassword(PASSWORD);

        // Assert
        result.Should().NotBeEquivalentTo(PASSWORD);
    }

    [Fact]
    public void HashPassword_OnNotPassingIterationCount_ShouldBeCalledFourTimes()
    {
        // Arrange
        var mockService = new Mock<PasswordService>(new ConfigurationFixture());
        mockService
            .Setup(p => p.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .CallBase();

        var sut = mockService.Object;

        // Act
        sut.HashPassword(PASSWORD);

        // Assert
        mockService.Verify(service =>
            service.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()),
            Times.Exactly(THREE_ITERATIONS + 1)
        );
    }

    [Fact]
    public void HashPassword_OnPassingIterationCount_ShouldBeCalledIterationPlusOneTimes()
    {
        // Arrange
        var mockService = new Mock<PasswordService>(new ConfigurationFixture());
        mockService
            .Setup(p => p.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .CallBase();

        var sut = mockService.Object;

        // Act
        sut.HashPassword(PASSWORD, iterations: TWO_ITERATIONS);

        // Assert
        mockService.Verify(service =>
            service.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()),
            Times.Exactly(TWO_ITERATIONS + 1)
        );
    }

    [Fact]
    public void HashPassword_OnPassingIterationCountEqualsZero_ShouldReturnSamePassword()
    {
        // Arrange
        var sut = new PasswordService(new ConfigurationFixture());

        // Act
        var result = sut.HashPassword(PASSWORD, iterations: ZERO_ITERATIONS);

        // Assert
        result.Should().BeEquivalentTo(PASSWORD);
    }

    [Fact]
    public void HashPassword_OnPassingNoSalt_ShouldCallGenerateSaltMethod()
    {
        // Arrange
        var mockService = new Mock<PasswordService>(new ConfigurationFixture());
        mockService
            .Setup(p => p.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .CallBase();
        mockService
            .Setup(p => p.GenerateSalt())
            .CallBase();

        var sut = mockService.Object;

        // Act
        sut.HashPassword(PASSWORD);

        // Assert
        mockService.Verify(service => service.GenerateSalt(), Times.Once);
    }

    [Fact]
    public void HashPassword_OnPassingSalt_ShouldNotCallGenerateSaltMethod()
    {
        // Arrange
        var mockService = new Mock<PasswordService>(new ConfigurationFixture());
        mockService
            .Setup(p => p.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .CallBase();
        mockService
            .Setup(p => p.GenerateSalt())
            .CallBase();

        var sut = mockService.Object;

        // Act
        sut.HashPassword(PASSWORD, salt: SALT);

        // Assert
        mockService.Verify(service => service.GenerateSalt(), Times.Never);
    }

    #endregion HashPassword

    #region GenerateSalt

    [Fact]
    public void GenerateSalt_ReturnString()
    {
        // Arrange
        var sut = new PasswordService(new ConfigurationFixture());

        // Act
        var result = sut.GenerateSalt();

        // Assert
        result.Should().BeOfType<string>();
    }

    [Fact]
    public void GenerateSalt_CallingTwoTimes_ReturnDifferentString()
    {
        // Arrange
        var sut = new PasswordService(new ConfigurationFixture());

        // Act
        var resultOne = sut.GenerateSalt();
        var resultTwo = sut.GenerateSalt();

        // Assert
        resultOne.Should().NotBeEquivalentTo(resultTwo);
    }

    #endregion GenerateSalt
}