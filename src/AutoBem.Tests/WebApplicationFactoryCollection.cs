using Xunit;

namespace AutoBem.Tests
{
    [CollectionDefinition("WebApi Collection")]
    public class WebApplicationFactoryCollection : ICollectionFixture<WebApplicationFactory>
    {
    }
}
