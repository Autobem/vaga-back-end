using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Queries.Details;
using System;

namespace AutoBem.Application.Clients.Queries.Details
{
    public class DetailsClientResult : DetailsResult<Client>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public override DetailsResult<Client> FromModel(Client client)
        {
            if (client is null)
            {
                return null;
            }

            this.Id = client.Id.Value;
            this.Name = client.Name;
            this.CPF = client.CPF.Value;
            this.Birthday = client.Birthday;

            return this;
        }
    }
}
