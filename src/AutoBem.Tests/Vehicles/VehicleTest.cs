using AutoBem.Application.Vehicles.Commands.Create;
using AutoBem.Application.Vehicles.Commands.Update;
using AutoBem.Application.Vehicles.Queries.Details;
using AutoBem.Infrastructure.Vehicles.Entities;
using AutoBem.Tests.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AutoBem.Tests
{
    [Collection("WebApi Collection")]
    public class VehicleTest
    {
        public VehicleTest(WebApplicationFactory factory)
        {
            this.Factory = factory;
        }

        public WebApplicationFactory Factory { get; }

        public void BeforeEachTest()
        {
            this.Factory.InitializeTestDatabase<VehicleSeed>();
        }

        [Fact]
        public async Task GetVehicleById_SuccessAsync()
        {
            this.BeforeEachTest();

            var result = await this.Factory
                .GetAsync<DetailsVehicleResult>($"/api/Vehicles/{VehicleSeed.Vehicle01.Id}")
                .ConfigureAwait(false);

            Assert.Equal(result.Content.Data.Color, VehicleSeed.Vehicle01.Color);
            Assert.Equal(result.Content.Data.LicensePlate, VehicleSeed.Vehicle01.LicensePlate);
            Assert.Equal(result.Content.Data.OwnerId, VehicleSeed.Vehicle01.OwnerId);
        }

        [Fact]
        public async Task ListAllVehicle_SuccessAsync()
        {
            this.BeforeEachTest();
            var seed = new VehicleSeed().GetSeed()
                .Where(e => e is VehicleEntity)
                .ToList();

            var result = await this.Factory
                .GetAsync<List<DetailsVehicleResult>>($"/api/Vehicles/list")
                .ConfigureAwait(false);

            Assert.Equal(result.Content.Data.Count, seed.Count);

            var vehicle01 = result.Content.Data
                .Where(e => e.Id == VehicleSeed.Vehicle01.Id)
                .FirstOrDefault();

            Assert.Equal(vehicle01.Color, VehicleSeed.Vehicle01.Color);
            Assert.Equal(vehicle01.LicensePlate, VehicleSeed.Vehicle01.LicensePlate);
            Assert.Equal(vehicle01.OwnerId, VehicleSeed.Vehicle01.OwnerId);
            Assert.Equal(vehicle01.OwnerName, VehicleSeed.Vehicle01.Owner.Name);

            var Vehicle02 = result.Content.Data
                .Where(e => e.Id == VehicleSeed.Vehicle02.Id)
                .FirstOrDefault();

            Assert.Equal(Vehicle02.Color, VehicleSeed.Vehicle02.Color);
            Assert.Equal(Vehicle02.LicensePlate, VehicleSeed.Vehicle02.LicensePlate);
            Assert.Equal(Vehicle02.OwnerId, VehicleSeed.Vehicle02.OwnerId);
            Assert.Equal(Vehicle02.OwnerName, VehicleSeed.Vehicle02.Owner.Name);
        }

        [Fact]
        public async Task CreateVehicle_SuccessAsync()
        {
            this.BeforeEachTest();

            var command = new CreateVehicleCommand()
            {
                Color = "Green",
                LicensePlate = "FDS-5745",
                OwnerId = VehicleSeed.Everton.Id
            };

            var resultId = await this.Factory
                .PostAsync<CreateVehicleResult>($"/api/Vehicles", command)
                .ConfigureAwait(false);

            var resultVehicle = await this.Factory
                .GetAsync<DetailsVehicleResult>($"/api/Vehicles/{resultId.Content.Data.Id}")
                .ConfigureAwait(false);

            Assert.Equal(resultVehicle.Content.Data.Color, command.Color);
            Assert.Equal(resultVehicle.Content.Data.LicensePlate, command.LicensePlate);
            Assert.Equal(resultVehicle.Content.Data.OwnerId, command.OwnerId);
        }

        [Fact]
        public async Task UpdateVehicle_SuccessAsync()
        {
            this.BeforeEachTest();

            var command = new UpdateVehicleCommand()
            {
                Id = VehicleSeed.Vehicle01.Id,
                Color = "Green",
                LicensePlate = "FDS-5745",
                OwnerId = VehicleSeed.Everton.Id
            };

            await this.Factory
                .PutAsync($"/api/Vehicles/{VehicleSeed.Vehicle01.Id}", command)
                .ConfigureAwait(false);

            var resultVehicle = await this.Factory
                .GetAsync<DetailsVehicleResult>($"/api/Vehicles/{VehicleSeed.Vehicle01.Id}")
                .ConfigureAwait(false);

            Assert.Equal(resultVehicle.Content.Data.Color, command.Color);
            Assert.Equal(resultVehicle.Content.Data.LicensePlate, command.LicensePlate);
            Assert.Equal(resultVehicle.Content.Data.OwnerId, command.OwnerId);
        }

        [Fact]
        public async Task DeleteVehicle_SuccessAsync()
        {
            this.BeforeEachTest();

            await this.Factory
                .DeleteAsync($"/api/Vehicles/{VehicleSeed.Vehicle01.Id}")
                .ConfigureAwait(false);

            var resultVehicle = await this.Factory
                .GetAsync<DetailsVehicleResult>($"/api/Vehicles/{VehicleSeed.Vehicle01.Id}")
                .ConfigureAwait(false);

            Assert.Null(resultVehicle.Content);
        }


        [Fact]
        public async Task GetVehicleByIdWithNonexistentId_FailAsync()
        {
            this.BeforeEachTest();

            var result = await this.Factory
                .GetAsync<DetailsVehicleResult>($"/api/Vehicles/c5a9f566-43e6-45f8-a268-3cd1d2a6d902")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public async Task CreateVehicleWithExistentLicensePlate_FailAsync()
        {
            this.BeforeEachTest();

            var command = new CreateVehicleCommand()
            {
                Color = "Green",
                LicensePlate = VehicleSeed.Vehicle01.LicensePlate,
                OwnerId = VehicleSeed.Everton.Id
            };

            var result = await this.Factory
                .PostAsync<CreateVehicleResult>($"/api/Vehicles", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task CreateVehicleWithInvalidLicensePlate_FailAsync()
        {
            this.BeforeEachTest();

            var command = new
            {
                Color = "Green",
                LicensePlate = "FDS-574",
                OwnerId = VehicleSeed.Everton.Id
            };

            var result = await this.Factory
                .PostAsync<CreateVehicleResult>($"/api/Vehicles", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task CreateVehicleWithInvalidOwner_FailAsync()
        {
            this.BeforeEachTest();

            var command = new
            {
                Color = "Green",
                LicensePlate = "FDS-574",
                OwnerId = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d935")
            };

            var result = await this.Factory
                .PostAsync<CreateVehicleResult>($"/api/Vehicles", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateVehicleWithInvalidLicensePlate_FailAsync()
        {
            this.BeforeEachTest();

            var command = new
            {
                Id = VehicleSeed.Vehicle01.Id,
                Color = "Green",
                LicensePlate = "FDS-574",
                OwnerId = VehicleSeed.Everton.Id
            };

            var result = await this.Factory
                 .PutAsync($"/api/Vehicles/{VehicleSeed.Vehicle01.Id}", command)
                 .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateVehicleByIdWithNonexistentId_FailAsync()
        {
            this.BeforeEachTest();
            var command = new UpdateVehicleCommand()
            {
                Id = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d222"),
                Color = "Green",
                LicensePlate = "FDS-5745",
                OwnerId = VehicleSeed.Everton.Id
            };

            var result = await this.Factory
                .PutAsync($"/api/Vehicles/{Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d222")}", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateVehicleByIdWithInvalidOwner_FailAsync()
        {
            this.BeforeEachTest();
            var command = new UpdateVehicleCommand()
            {
                Id = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d222"),
                Color = "Green",
                LicensePlate = "FDS-5745",
                OwnerId = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d232")
            };

            var result = await this.Factory
                .PutAsync($"/api/Vehicles/{Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d222")}", command)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteVehicleWithNonexistentId_FailAsync()
        {
            this.BeforeEachTest();

            var result = await this.Factory
                .DeleteAsync($"/api/Vehicles/fdef226a-9e62-45cb-beff-e27fb3654cc3")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
