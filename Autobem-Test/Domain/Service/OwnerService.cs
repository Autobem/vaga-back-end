using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Models;
using Entities.Entities;

namespace Domain.Service;

public class OwnerService : IOwnerService
{
    private readonly IBaseRepository<Owner> _repository;
    private readonly IMapper _mapper;

    public OwnerService(IBaseRepository<Owner> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OwnerModel>> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<OwnerModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<OwnerModel> Insert(OwnerModel owner)
    {
        throw new NotImplementedException();
    }

    public async Task Update(OwnerModel owner)
    {
        throw new NotImplementedException();
    }
}