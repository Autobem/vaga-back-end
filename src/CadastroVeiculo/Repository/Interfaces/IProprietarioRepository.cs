using Domain.Dtos;
using Domain.Entidades;

namespace Repository.Interfaces
{
    public interface IProprietarioRepository
    {
        Task<Proprietario> GetById(int Id);
        Task<Proprietario> GetByDocumento(string documento);
        Task<IEnumerable<Veiculo>> GetByVeiculo(string documento);
        Task<int> Add(Proprietario proprietario);
        Task<int> Put(Proprietario proprietario);
        Task Delete(int Id);

    }
}
