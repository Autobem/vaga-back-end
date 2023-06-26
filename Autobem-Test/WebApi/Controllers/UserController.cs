﻿using Domain.Contracts.Service;
using Domain.Models;
using Domain.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.Delete(id);
        return Accepted();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _userService.Get());
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _userService.GetById(id);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Insert(CreateUserModel user)
    {
        return Created(nameof(CreateUserModel), await _userService.Insert(user));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserModel user)
    {
        await _userService.Update(user);
        return Accepted();
    }
}