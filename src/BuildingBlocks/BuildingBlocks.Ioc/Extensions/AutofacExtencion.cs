using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;

namespace BuildingBlocks.Ioc.Extensions
{
    public static class AutofacExtencion
    {
        public static IWebHostBuilder AddAutoInjection(this IWebHostBuilder configureServices)
        {
            return configureServices.ConfigureServices(e => e.AddAutofac());
        }
    }
}
