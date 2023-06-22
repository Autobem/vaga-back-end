using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
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

    public Task Delete(Owner owner)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Owner>> Get()
    {
        throw new NotImplementedException();
    }

    public Task GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Insert(Owner owner)
    {
        throw new NotImplementedException();
    }

    public Task Update(Owner owner)
    {
        throw new NotImplementedException();
    }
}