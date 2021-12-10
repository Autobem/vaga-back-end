using Projeto.Domain.Aggregates.Usuarios.Models;
using Projeto.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Usuarios.Contracts.Services
{
    public interface IUsuarioDomainService : IBaseDomainService<Usuario>
    {
        Usuario GetByEmail(string email);
        Usuario GetByEmailAndSenha(string email, string senha);
    }
}

