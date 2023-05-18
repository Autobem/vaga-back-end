using DevAssuncaoCarros.Business.Models;


namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        public Task<Proprietario> ObterProprietarioCarros();
        public Task<Proprietario> ObterCarrosPorProprietarios(Guid id);
        public Task<Proprietario> ObterProprietarioEndereco(Guid id);
    }
}
