using AutoMapper;
using Domain.Dtos;
using Domain.Entidades;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IMapper _mapper;
        private readonly IProprietarioRepository _repository;

        public ProprietarioService(
            IMapper mapper,
            IProprietarioRepository repository
        )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Add(ProprietarioDto proprietario)
        {
            return await _repository.Add(_mapper.Map<Proprietario>(proprietario));
        }

        public async Task Delete(int Id)
        {
            await _repository.Delete(Id);
        }

        public async Task<ProprietarioDto> GetByDocumento(string documento)
        {
            return _mapper.Map<ProprietarioDto>(await _repository.GetByDocumento(documento));
        }

        public async Task<ProprietarioDto> GetById(int Id)
        {
            return _mapper.Map<ProprietarioDto>(await _repository.GetById(Id));
        }

        public async Task<IEnumerable<VeiculoResponseDto>> GetByVeiculo(string documento)
        {
            return _mapper.Map<IEnumerable<VeiculoResponseDto>>(await _repository.GetByVeiculo(documento));
        }

        public async Task<int> Put(ProprietarioUpdateDto proprietario)
        {
            return await _repository.Put(_mapper.Map<Proprietario>(proprietario));
        }
    }
}
