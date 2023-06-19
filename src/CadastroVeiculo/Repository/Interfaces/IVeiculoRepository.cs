using Domain.Entidades;

namespace Repository.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> GetById(int Id);
        Task<Veiculo> GetByDocumento(long documento);
        Task<int> Add(Veiculo veiculo);
        Task<int> Put(Veiculo veiculo);
        Task Delete(int Id);
    }
}
