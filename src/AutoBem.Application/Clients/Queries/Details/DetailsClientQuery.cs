using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Queries.Details;
using System;

namespace AutoBem.Application.Clients.Queries.Details
{
    public class DetailsClientQuery : DetailsQuery<Client, DetailsClientResult>
    {
        public DetailsClientQuery(Guid id) : base(id)
        {
        }
    }
}
