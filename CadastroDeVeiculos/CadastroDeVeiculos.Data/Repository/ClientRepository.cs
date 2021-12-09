using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Domain.Entities;

namespace CadastroDeVeiculos.Data.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {

        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
           
        }
    }
}
