using Projeto.Domain.Aggregates.Usuarios.Models;
using Projeto.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Usuarios.Contracts.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
    }
}
