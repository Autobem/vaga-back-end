using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Models;
using Domain.Models.UserModels;
using Domain.Validators.User;
using Entities.Entities;
using Entities.Enums;
using FluentValidation;

namespace Domain.Service;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _repository;
    private readonly IPasswordService _passwordService;
    private readonly IMapper _mapper;

    public UserService(IBaseRepository<User> repository, IPasswordService passwordService, IMapper mapper)
    {
        _repository = repository;
        _passwordService = passwordService;
        _mapper = mapper;
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
    }

    public async Task<List<GetUserModel>> Get()
    {
        var users = await _repository.Get();
        return _mapper.Map<List<GetUserModel>>(users);
    }

    public async Task<GetUserModel> GetById(Guid id)
    {
        var user = await _repository.GetById(id);
        return _mapper.Map<GetUserModel>(user);
    }

    public async Task<GetUserModel> Insert(CreateUserModel user)
    {
        var validator = new CreateUserModelValidator();
        await validator.ValidateAndThrowAsync(user);

        var insertUser = _mapper.Map<User>(user);

        insertUser.PasswordSalt = _passwordService.GenerateSalt();
        insertUser.Password = _passwordService.HashPassword(insertUser.Password);
        insertUser.Status = StatusEnum.ACTIVE;

        var result = await _repository.Insert(insertUser);
        return _mapper.Map<GetUserModel>(result);
    }

    public async Task Update(UpdateUserModel user)
    {
        var validator = new UpdateUserModelValidator();
        await validator.ValidateAndThrowAsync(user);

        var updateUser = _mapper.Map<User>(user);

        var actualUser = await _repository.GetById(updateUser.Id);
        updateUser.Password = actualUser.Password;
        updateUser.PasswordSalt = actualUser.PasswordSalt;

        await _repository.Update(updateUser);
    }

    private (string, string) GeneratePassword(string pass)
    {
        var passwordSalt = _passwordService.GenerateSalt();
        var passwordHash = _passwordService.HashPassword(pass, passwordSalt);
        return (passwordHash, passwordSalt);
    }
}