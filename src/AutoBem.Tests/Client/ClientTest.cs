using AutoBem.Application.Clients.Commands.Create;
using AutoBem.Application.Clients.Commands.Update;
using AutoBem.Application.Clients.Queries.Details;
using AutoBem.Infrastructure.Clients.Entities;
using AutoBem.Tests.Client;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AutoBem.Tests
{
    [Collection("WebApi Collection")]
    public class ClientTest
    {
        public ClientTest(WebApplicationFactory factory)
        {
            this.Factory = factory;
        }

        public WebApplicationFactory Factory { get; }

        public void BeforeEachTest()
        {
            this.Factory.InitializeTestDatabase<ClientSeed, ClientEntity>();
        }

        [Fact]
        public async Task GetClientById_SuccessAsync()
        {
            this.BeforeEachTest();

            var result = await this.Factory
                .GetAsync<DetailsClientResult>($"/api/clients/{ClientSeed.Everton.Id}")
                .ConfigureAwait(false);

            Assert.Equal(result.Content.Data.CPF, ClientSeed.Everton.CPF);
            Assert.Equal(result.Content.Data.Name, ClientSeed.Everton.Name);
            Assert.Equal(result.Content.Data.Birthday, ClientSeed.Everton.Birthday);
        }

        [Fact]
        public async Task CreateClient_SuccessAsync()
        {
            this.BeforeEachTest();

            var command = new CreateClientCommand()
            {
                Name = "Matheus",
                CPF = "66184000071",
                Birthday = DateTimeOffset.Parse("10/02/2021"),
            };

            var resultId = await this.Factory
                .PostAsync<CreateClientResult>($"/api/clients", command)
                .ConfigureAwait(false);

            var resultClient = await this.Factory
                .GetAsync<DetailsClientResult>($"/api/clients/{resultId.Content.Data.Id}")
                .ConfigureAwait(false);

            Assert.Equal(resultClient.Content.Data.CPF, command.CPF);
            Assert.Equal(resultClient.Content.Data.Name, command.Name);
            Assert.Equal(resultClient.Content.Data.Birthday, command.Birthday);
        }

        [Fact]
        public async Task UpdateClient_SuccessAsync()
        {
            this.BeforeEachTest();

            var command = new UpdateClientCommand()
            {
                Id = ClientSeed.Everton.Id,
                Name = "Matheus",
                CPF = "66184000071",
                Birthday = DateTimeOffset.Parse("10/02/2021"),
            };

            await this.Factory
                .PutAsync($"/api/clients/{ClientSeed.Everton.Id}", command)
                .ConfigureAwait(false);

            var resultClient = await this.Factory
                .GetAsync<DetailsClientResult>($"/api/clients/{ClientSeed.Everton.Id}")
                .ConfigureAwait(false);

            Assert.Equal(resultClient.Content.Data.Name, command.Name);
            Assert.Equal(resultClient.Content.Data.CPF, command.CPF);
            Assert.Equal(resultClient.Content.Data.Birthday, command.Birthday);
        }

        [Fact]
        public async Task DeleteClient_SuccessAsync()
        {
            this.BeforeEachTest();

            await this.Factory
                .DeleteAsync($"/api/clients/{ClientSeed.Everton.Id}")
                .ConfigureAwait(false);

            var resultClient = await this.Factory
                .GetAsync<DetailsClientResult>($"/api/clients/{ClientSeed.Everton.Id}")
                .ConfigureAwait(false);

            Assert.Null(resultClient.Content);
        }


        [Fact]
        public async Task GetClientByIdWithNonexistentId_FailAsync()
        {
            this.BeforeEachTest();

            var result = await this.Factory
                .GetAsync<DetailsClientResult>($"/api/clients/c5a9f566-43e6-45f8-a268-3cd1d2a6d902")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public async Task CreateClientWithExistentCPF_FailAsync()
        {
            this.BeforeEachTest();

            var command = new CreateClientCommand()
            {
                Name = "Matheus",
                CPF = ClientSeed.Everton.CPF,
                Birthday = DateTimeOffset.Parse("10/02/2021"),
            };

            var result = await this.Factory
                .PostAsync<CreateClientResult>($"/api/clients", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task CreateClientWithInvalidCPF_FailAsync()
        {
            this.BeforeEachTest();

            var command = new
            {
                Name = "Matheus",
                CPF = "66184000073",//Invalid
                Birthday = DateTimeOffset.Parse("10/02/2021"),
            };

            var result = await this.Factory
                .PostAsync<CreateClientResult>($"/api/clients", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateClientWithInvalidCPF_FailAsync()
        {
            this.BeforeEachTest();

            var command = new
            {
                Id = ClientSeed.Everton.Id,
                Name = "Matheus",
                CPF = "66184000073",
                Birthday = DateTimeOffset.Parse("10/02/2021"),
            };

            var result = await this.Factory
                 .PutAsync($"/api/clients/{ClientSeed.Everton.Id}", command)
                 .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateClientByIdWithNonexistentId_FailAsync()
        {
            this.BeforeEachTest();
            var command = new UpdateClientCommand()
            {
                Id = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d222"),
                Name = "Matheus",
                CPF = ClientSeed.Everton.CPF,
                Birthday = DateTimeOffset.Parse("10/02/2021"),
            };

            var result = await this.Factory
                .PutAsync($"/api/clients/{Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d222")}", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteClientWithNonexistentId_FailAsync()
        {
            this.BeforeEachTest();

            var result = await this.Factory
                .DeleteAsync($"/api/clients/fdef226a-9e62-45cb-beff-e27fb3654cc3")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteClientWithVehicle_FailAsync()
        {
            this.BeforeEachTest();

            var result = await this.Factory
                .DeleteAsync($"/api/clients/{ClientSeed.Jean.Id}")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
