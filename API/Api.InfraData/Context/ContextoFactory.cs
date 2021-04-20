using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.InfraData.Context
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=NTBPLGCF84T73\\SQLEXPRESS;Initial Catalog=dbteste;Persist Security Info=True;User ID=sa;Password=teste;MultipleActiveResultSets=True";
            var optionsBuildder = new DbContextOptionsBuilder<Contexto>();
            optionsBuildder.UseSqlServer(connectionString);

            return new Contexto(optionsBuildder.Options);
        }
    }
}