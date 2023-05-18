using DevAssuncaoCarros.Business.Models;


namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface ICarroService : IDisposable
    {
        Task<bool> AddCarro(Carro carro);
        Task<bool> AtualizarCarro(Carro carro);
        Task<bool> RemoverCarro(Guid id);
    }
}
