using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssuncaoCarros.Business.Models
{
    public abstract class Entidade
    {
        public Guid Id { get; set; }

        protected Entidade ()
        {
            Id = new Guid();
        }
    }
}
