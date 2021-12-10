using Projeto.Domain.Aggregates.Veiculos.Contracts.Repositories;
using Projeto.Domain.Aggregates.Veiculos.Models;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Infra.Data.Repositories
{
    public class VeiculoRepository
        : BaseRepository<Veiculo>, IVeiculoRepository
    {
        private readonly DataContext dataContext;

        public VeiculoRepository(DataContext dataContext)
              : base(dataContext)
        {
            this.dataContext = dataContext;
        }        
    }
}
