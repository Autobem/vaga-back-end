using DevAssuncaoCarros.Business.Models;

namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface ICarroRepository : IRepository<Carro>
    {
        public Task<IEnumerable<Carro>> ObterCarrosProprietario(Guid id);
    }
}
