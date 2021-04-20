using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.DTO.Pessoa;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<PessoaDTOPost> PostAsync(PessoaDTO model);
        Task<PessoaDTOPut> PutAsync(PessoaDTOPutRequest model);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<PessoaDTO>> GetAsync();
        Task<PessoaDTO> GetAsync(int id);
    }
}