using BuildingBlocks.Infraestructure;
using BuildingBlocks.Ioc.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AutoBem.Infrastructure
{
    [Injectable]
    public class CoreDbContext : DbContext, IDbContext
    {
        public CoreDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    }
}
