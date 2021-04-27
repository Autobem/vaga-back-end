using BuildingBlocks.Domain.Generics.CPF;
using BuildingBlocks.Domain.Models;
using System;

namespace AutoBem.Domain.Clients.Models
{
    public class Client : IModel
    {
        public Guid? Id { get; set; }

        public String Name { get; set; }

        public CPF CPF { get; set; }

        public DateTimeOffset Birthday { get; set; }
    }
}
