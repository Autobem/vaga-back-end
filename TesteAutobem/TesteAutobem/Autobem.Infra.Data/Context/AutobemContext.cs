using Autobem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autobem.Infra.Data.Context
{
    public class AutobemContext : DbContext
    {
        public AutobemContext() : base("AutobemConnection")
        {

        }

        public DbSet<Cor> Cores { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
