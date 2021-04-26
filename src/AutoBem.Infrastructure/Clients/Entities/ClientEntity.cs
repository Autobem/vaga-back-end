using BuildingBlocks.Infraestructure.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoBem.Infrastructure.Clients.Entities
{
    public class ClientEntity : CommonEntity
    {
        [StringLength(255)]
        public String Name { get; set; }

        [StringLength(16)]
        public String CPF { get; set; }

        public DateTimeOffset Birthday { get; set; }
    }
}
