using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Tests.Fixture;

public class ConfigurationFixture : IConfiguration
{
    public string? this[string key] { get => "key"; set => throw new NotImplementedException(); }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        return new List<ConfigurationSectionFixture>();
    }

    public IChangeToken GetReloadToken()
    {
        return null;
    }

    public IConfigurationSection GetSection(string key)
    {
        return new ConfigurationSectionFixture();
    }
}