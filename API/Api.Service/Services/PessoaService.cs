using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.DTO.Pessoa;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepository<Pessoa> _repository;
        private readonly IMapper _mapper;

        public PessoaService(IRepository<Pessoa> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        
        
        public async Task<int> DeleteAsync(int id)
        {
           return await _repository.DeletarAsync(id);
        }

        public async Task<IEnumerable<PessoaDTO>> GetAsync()
        {
            var entidades = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<PessoaDTO>>(entidades);
        }

        public async Task<PessoaDTO> GetAsync(int id)
        {
            var entidade = await _repository.GetAsync(id);
            return _mapper.Map<PessoaDTO>(entidade)??(new PessoaDTO());
        }

        public async Task<PessoaDTOPost> PostAsync(PessoaDTO model)
        {
            //mapeando meu dto para modelo
            var modelo = _mapper.Map<PessoaModel>(model);

            //mapeando meu modelo para entidade
            var entidade = _mapper.Map<Pessoa>(modelo);

            //executando persistencia
            var result = await _repository.AdicionarAsync(entidade);

            return _mapper.Map<PessoaDTOPost>(result);
        }

        public async Task<PessoaDTOPut> PutAsync(PessoaDTOPutRequest model)
        {
            //mapeando meu dto para modelo
            var modelo = _mapper.Map<PessoaModel>(model);

            //mapeando meu modelo para entidade
            var entidade = _mapper.Map<Pessoa>(modelo);

            //executando persistencia
            var result = await _repository.AtualizarAsync(entidade);

            return _mapper.Map<PessoaDTOPut>(result);
        }
    }
}