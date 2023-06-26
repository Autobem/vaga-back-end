using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Tests.Fixture;

public class ConfigurationSectionFixture : IConfigurationSection
{
    public string? this[string key] { get => "Key"; set => throw new NotImplementedException(); }

    public string Key => "";

    public string Path => "";

    public string? Value { get => "string"; set => throw new NotImplementedException(); }

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