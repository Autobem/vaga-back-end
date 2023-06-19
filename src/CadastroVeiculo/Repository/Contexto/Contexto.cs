using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repository.Contexto
{
    public class Contexto : IDesignTimeDbContextFactory<ContextoDB>
    {
        public ContextoDB CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = @"Data Source=DESKTOP-I788LKG\SQLEXPRESS;Initial Catalog=CadastroVeiculos;Integrated Security=True;Encrypt=False;";
            var optionsBuilder = new DbContextOptionsBuilder<ContextoDB>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ContextoDB(optionsBuilder.Options);
        }
    
    }
}
