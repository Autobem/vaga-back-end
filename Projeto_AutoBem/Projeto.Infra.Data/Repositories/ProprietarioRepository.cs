using Projeto.Domain.Aggregates.Veiculos.Contracts.Repositories;
using Projeto.Domain.Aggregates.Veiculos.Models;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class ProprietarioRepository
         : BaseRepository<Proprietario>, IProprietarioRepository
    {
        private readonly DataContext dataContext;

        public ProprietarioRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<Proprietario> ListarTodos()
        {
            return dataContext.Proprietarios.Include(x => x.Veiculos).ToList();
        }
    }
}
