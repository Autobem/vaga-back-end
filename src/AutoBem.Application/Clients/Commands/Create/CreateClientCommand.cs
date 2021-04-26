using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Commands.Create;
using System;

namespace AutoBem.Application.Clients.Commands.Create
{
    public class CreateClientCommand : CreateCommand<Client, CreateClientResult>
    {
        public String Name { get; set; }

        public String CPF { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public override Client ToModel()
        {
            return new Client()
            {
                Name = this.Name,
                CPF = this.CPF,
                Birthday = this.Birthday
            };
        }
    }
}
