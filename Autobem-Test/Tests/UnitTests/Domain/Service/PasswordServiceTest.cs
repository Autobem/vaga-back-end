using Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Tests.UnitTests.Domain.Service;

public class PasswordServiceTest
{
    private const string PASSWORD = "password";
    private const string SALT = "salt";
    private const int THREE_HASHES = 3;
    private const string CONFIGURATION_KEY = "Key";

    public class FakeConfiguration : IConfiguration
    {
        public string? this[string key] { get => CONFIGURATION_KEY; set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return new List<FakeConfigurationSection>();
        }

        public IChangeToken GetReloadToken()
        {
            return null;
        }

        public IConfigurationSection GetSection(string key)
        {
            return new FakeConfigurationSection();
        }
    }

    public class FakeConfigurationSection : IConfigurationSection
    {
        public string? this[string key] { get => CONFIGURATION_KEY; set => throw new NotImplementedException(); }

        public string Key => "";

        public string Path => "";

        public string? Value { get => "string"; set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return new List<FakeConfigurationSection>();
        }

        public IChangeToken GetReloadToken()
        {
            return null;
        }

        public IConfigurationSection GetSection(string key)
        {
            return new FakeConfigurationSection();
        }
    }

    [Fact]
    public void HashPassword_OnOnlyPassingPassword_ReturnString()
    {
        // Arrange
        var sut = new PasswordService(new FakeConfiguration());

        // Act
        var result = sut.HashPassword(PASSWORD);

        // Assert
        result.Should().BeOfType<string>();
    }

    [Fact]
    public void HashPassword_OnNotPassingIterationCount_ShouldBeCalledFourTimes()
    {
        // Arrange
        var mockService = new Mock<PasswordService>(new FakeConfiguration());
        mockService
            .Setup(p => p.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .CallBase();

        var sut = mockService.Object;

        // Act
        sut.HashPassword(PASSWORD);

        // Assert
        mockService.Verify(service =>
            service.HashPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()),
            Times.Exactly(THREE_HASHES + 1)
        );
    }
}