using DevAssuncaoCarros.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        public Task<Endereco> ObterEnderecoProprietario(Guid id);
    }
}
