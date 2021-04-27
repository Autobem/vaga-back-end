using AutoBem.Application.Users.Query.Register;
using AutoBem.Infrastructure.Extensions;
using AutoBem.WebApi;
using BuildingBlocks.Infraestructure;
using BuildingBlocks.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

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

        public void Signin(string userName, string password)
        {
            var signin = new SigninUserQuery()
            {
                Username = userName,
                Password = password
            };

            var result = this.PostAsync<SigninUserResult>("api/users", signin).Result;
            var token = result.Content.Data.Token;

            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
