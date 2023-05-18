using DevAssuncaoCarros.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssuncaoCarros.Business.Interfaces
{
    public interface ICarroRepository : IRepository<Carro>
    {
        public Task<Carro> ObterCarroProprietario(Guid id);
    }
}
