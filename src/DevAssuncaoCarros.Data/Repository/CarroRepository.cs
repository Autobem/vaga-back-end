using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;
using DevAssuncaoCarros.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace DevAssuncaoCarros.Data.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(CarroContext carroContext) : base(carroContext)
        {
        }

        public async Task<Carro> ObterCarroProprietario(Guid id)
        {
            return await carroContext.Carros.AsNoTracking()
                            .Include(x => x.Proprietario).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
