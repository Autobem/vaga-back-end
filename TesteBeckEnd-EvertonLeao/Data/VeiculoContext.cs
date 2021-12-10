using Microsoft.EntityFrameworkCore;
using VeiculosApi.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TesteBeckEnd_EvertonLeao.Data
{
    public class VeiculoContext : DbContext
    {
        public VeiculoContext(DbContextOptions<VeiculoContext> opt) : base (opt)
        {

        }
        public DbSet<Veiculo> Veiculos { get; set; } 
    }
}
