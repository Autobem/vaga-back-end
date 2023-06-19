using AutoMapper;
using Domain.Dtos;
using Domain.Entidades;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _repository;

        public VeiculoService(
            IMapper mapper,
            IVeiculoRepository repository
        )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Add(VeiculoDto veiculo)
        {
            return await _repository.Add(_mapper.Map<Veiculo>(veiculo));
        }

        public async Task Delete(int Id)
        {
            await _repository.Delete(Id);
        }

        public async Task<VeiculoDto> GetByDocumento(long documento)
        {
            return _mapper.Map<VeiculoDto>(await _repository.GetByDocumento(documento));
        }

        public async Task<VeiculoDto> GetById(int Id)
        {
            return _mapper.Map<VeiculoDto>(await _repository.GetById(Id));
        }

        public async Task<int> Put(VeiculoUpdateDto veiculo)
        {
            return await _repository.Put(_mapper.Map<Veiculo>(veiculo));
        }
    }
}
