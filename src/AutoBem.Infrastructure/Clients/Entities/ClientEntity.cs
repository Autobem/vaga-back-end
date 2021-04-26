using BuildingBlocks.Infraestructure.Entities;
using System;

namespace AutoBem.Infrastructure.Clients.Entities
{
    public class ClientEntity : CommonEntity
    {
        public String Name { get; set; }

        public String CPF { get; set; }

        public DateTimeOffset Birthday { get; set; }
    }
}
