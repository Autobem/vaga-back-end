using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Queries.List;
using System;

namespace AutoBem.Application.Clients.Queries.ListAll
{
    public class ListClientResult : ListResult<Client>
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String CPF { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public override ListResult<Client> FromModel(Client client)
        {
            this.Id = client.Id.Value;
            this.Name = client.Name;
            this.CPF = client.CPF.Value;
            this.Birthday = client.Birthday;

            return this;
        }
    }
}
