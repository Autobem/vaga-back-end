using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Models;
using Domain.Validators;
using Entities.Entities;
using FluentValidation;

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
        await _repository.Delete(id);
    }

    public async Task<List<OwnerModel>> Get()
    {
        var result = await _repository.Get();
        return _mapper.Map<List<OwnerModel>>(result);
    }

    public async Task<OwnerModel> GetById(Guid id)
    {
        var result = await _repository.GetById(id);
        return _mapper.Map<OwnerModel>(result);
    }

    public async Task<OwnerModel> Insert(OwnerModel owner)
    {
        var validator = new OwnerModelValidator();
        await validator.ValidateAndThrowAsync(owner);

        var insertOnwer = _mapper.Map<Owner>(owner);
        insertOnwer.InclusionDate = DateTime.UtcNow;
        insertOnwer.LastChange = DateTime.UtcNow;

        var result = await _repository.Insert(insertOnwer);
        return _mapper.Map<OwnerModel>(result);
    }

    public async Task Update(OwnerModel owner)
    {
        var validator = new UpdateOwnerModelValidator();
        await validator.ValidateAndThrowAsync(owner);

        var updateOwner = _mapper.Map<Owner>(owner);
        updateOwner.LastChange = DateTime.UtcNow;
        await _repository.Update(updateOwner);
    }
}