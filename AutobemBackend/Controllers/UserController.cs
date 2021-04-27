using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Domain.Entities;
using Model.Domain.Interfaces;
using Model.Service.Validators;
using System;
using System.Security.Cryptography;

namespace Model.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase
    {
        private IBaseService<User> _baseUserService;
        private ICryptographyService _cryptographyService;

        public UserController(IBaseService<User> baseUserService, ICryptographyService cryptographyService)
        {
            _baseUserService = baseUserService;
            _cryptographyService = cryptographyService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            user.Password = _cryptographyService.EncryptPassword(user.Password);

            return Execute(() => _baseUserService.Add<UserValidator>(user).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UserValidator>(user));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
