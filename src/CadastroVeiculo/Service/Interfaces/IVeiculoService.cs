using Domain.Dtos;

namespace Service.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoDto> GetById(int Id);
        Task<VeiculoDto> GetByDocumento(long documento);
        Task<int> Add(VeiculoDto veiculo);
        Task<int> Put(VeiculoUpdateDto veiculo);
        Task Delete(int Id);
    }
}
