using AutoBem.Infrastructure.Extensions;
using AutoBem.WebApi;
using BuildingBlocks.Infraestructure;
using BuildingBlocks.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace AutoBem.Tests
{
    public class WebApplicationFactory : BaseApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(services =>
            {
                services.AddDbContextMemory();
            });
        }

        public void InitializeTestDatabase<TSeedService>()
            where TSeedService : ISeed, new()

        {
            var context = this.Services.GetService(typeof(IDbContext)) as DbContext;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var seeds = new TSeedService().GetSeed();

            foreach (var entity in seeds)
            {
                context.AddRange(entity);
            }
            context.SaveChanges();
        }
    }
}
