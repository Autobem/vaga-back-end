using DevAssuncaoCarros.Business.Models;


namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface IProprietarioService : IDisposable
    {
        Task<bool> AddProprietario(Proprietario proprietario);
        Task<bool> AtualizarProprietario(Proprietario proprietario);
        Task<bool> RemoveProprietario(Guid id);
        Task AtualizarEndereco(Endereco endereco);
    }
}
