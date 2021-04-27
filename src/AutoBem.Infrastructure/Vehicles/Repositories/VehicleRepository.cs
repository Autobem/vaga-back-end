using AutoBem.Domain.Vehicles;
using AutoBem.Domain.Vehicles.Models;
using AutoBem.Infrastructure.Vehicles.Entities;
using BuildingBlocks.Infraestructure.Repositories;
using BuildingBlocks.Ioc.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AutoBem.Infrastructure.Vehicles.Repositories
{
    [Injectable]
    public class VehicleRepository : CrudRepository<Vehicle, VehicleEntity>, IVehicleRepository
    {
        public bool ExistLicensePlate(string licensePlate)
        {
            return this.DbSet
                .Where(e => e.LicensePlate == licensePlate)
                .AsNoTracking()
                .Any();
        }

        public override Vehicle Get(Guid id, CancellationToken token = default)
        {
            var entity = this.DbSet
                .Where(e => e.Id == id)
                .Include(e => e.Owner)
                .AsNoTracking()
                .FirstOrDefault();

            if (entity is null)
            {
                return null;
            }

            return this.Mapper.ToModel(entity);
        }

        public override IEnumerable<Vehicle> ListAll(CancellationToken cancellationToken)
        {
            return this.DbSet
                .Include(e => e.Owner)
                .AsNoTracking()
                .Select(e => this.Mapper.ToModel(e));
        }

        public bool OwnerHasVehicle(Guid ownerId)
        {
            return this.DbSet
               .Where(e => e.OwnerId == ownerId)
               .AsNoTracking()
               .Any();
        }
    }
}
