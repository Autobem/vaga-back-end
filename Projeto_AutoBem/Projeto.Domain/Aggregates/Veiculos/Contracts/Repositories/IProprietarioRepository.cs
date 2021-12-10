using Projeto.Domain.Aggregates.Veiculos.Models;
using Projeto.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Veiculos.Contracts.Repositories
{
    public interface IProprietarioRepository : IBaseRepository<Proprietario>
    {
        List<Proprietario> ListarTodos();
    }
}
