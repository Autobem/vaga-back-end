using DevAssuncaoCarros.Business.Models;

namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        public Task<Endereco> ObterEnderecoProprietario(Guid id);
    }
}
