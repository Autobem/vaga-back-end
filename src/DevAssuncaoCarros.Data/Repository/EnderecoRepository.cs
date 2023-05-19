using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;
using DevAssuncaoCarros.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace DevAssuncaoCarros.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CarroContext carroContext) : base(carroContext)
        {
        }

        public async Task<Endereco> ObterEnderecoProprietario(Guid id)
        {
            return await carroContext.Enderecos.AsNoTracking()
                            .Include(x => x.Proprietario).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
