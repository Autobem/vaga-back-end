using DevAssuncaoCarros.Business.Models;


namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        public Task<IEnumerable<Proprietario>> ObterProprietarioCarros();
        public Task<IEnumerable<Proprietario>> ObterCarrosPorProprietarios(Guid id);
        public Task<Proprietario> ObterProprietarioEndereco(Guid id);
    }
}
