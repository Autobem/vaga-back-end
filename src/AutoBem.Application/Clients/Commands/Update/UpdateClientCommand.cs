﻿using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Commands.Update;
using BuildingBlocks.Domain.Generics.CPF;
using System;

namespace AutoBem.Application.Clients.Commands.Update
{
    public class UpdateClientCommand : UpdateCommand<Client>
    {
        public string Name { get; set; }

        public CPF CPF { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public override Client ToModel()
        {
            return new Client()
            {
                Id = Id,
                Name = Name,
                CPF = CPF,
                Birthday = Birthday
            };
        }
    }
}
