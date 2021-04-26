using AutoBem.Domain.Clients.Models;
using AutoBem.Infrastructure.Clients.Entities;
using BuildingBlocks.Infraestructure.Converters;
using BuildingBlocks.Ioc.Attributes;
using System;

namespace AutoBem.Infrastructure.Clients.Converters
{

    [Injectable]
    public class ClientConvert : IMappedEntity<Client, ClientEntity>
    {
        public ClientEntity ToEntity(Client model)
        {
            return new ClientEntity()
            {
                Id = model.Id ?? Guid.NewGuid(),
                Name = model.Name,
                Birthday = model.Birthday,
                CPF = model.CPF.Value,
            };
        }

        public Client ToModel(ClientEntity entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new Client()
            {
                Id = entity.Id,
                CPF = entity.CPF,
                Name = entity.Name,
                Birthday = entity.Birthday
            };
        }
    }
}
