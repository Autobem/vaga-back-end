using Domain.Dtos;
using Domain.Entidades;

namespace Service.Interfaces
{
    public interface IProprietarioService
    {
        Task<ProprietarioDto> GetById(int Id);
        Task<ProprietarioDto> GetByDocumento(string documento);
        Task<IEnumerable<VeiculoResponseDto>> GetByVeiculo(string documento);
        Task<int> Add(ProprietarioDto proprietario);
        Task<int> Put(ProprietarioUpdateDto proprietario);
        Task Delete(int Id);
    }
}
