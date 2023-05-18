using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;
using DevAssuncaoCarros.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace DevAssuncaoCarros.Data.Repository
{
    public class ProprietarioRepository : Repository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(CarroContext carroContext) : base(carroContext)
        {
        }

        public async Task<IEnumerable<Proprietario>> ObterCarrosPorProprietarios(Guid id)
        {
            return await carroContext.Proprietarios.AsNoTracking()
                             .Include(x => x.Carros).Where(x => x.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Proprietario>> ObterProprietarioCarros()
        {
            return await carroContext.Proprietarios.AsNoTracking()
                            .Include(x => x.Carros).ToListAsync();
        }

        public async Task<Proprietario> ObterProprietarioEndereco(Guid id)
        {
            return await carroContext.Proprietarios.AsNoTracking()
                        .Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
