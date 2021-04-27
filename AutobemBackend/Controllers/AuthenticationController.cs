using Microsoft.AspNetCore.Mvc;
using Model.Domain.Entities;
using Model.Domain.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Model.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IBaseService<User> _baseUserService;
        private ICryptographyService _cryptographyService;
        public AuthenticationController(IBaseService<User> baseUserService, ICryptographyService cryptographyService)
        {
            _baseUserService = baseUserService;
            _cryptographyService = cryptographyService;
        }

        [HttpPost]
        public IActionResult Auth([FromBody] Authentication user)
        {
            if (user == null)
                return NotFound();

            var userInDatabase = _baseUserService.Get().Where(x => x.Email == user.Email);

            if(userInDatabase.Count() > 0)
            {
                if(_cryptographyService.VerifyPassword(user.Password, userInDatabase.First().Password))
                {
                    var client = new RestClient("https://aramos.us.auth0.com/oauth/token");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("application/json", "{\"client_id\":\"6jy88WeC87h7wq8QBHwpKXBTOwAsFKpq\",\"client_secret\":\"UlWV6Gu-qhivV1GTeBk9iFjAdAC9N7LUTsYrNXytBwC4ebFfJhG9fEuixLAcpHmj\",\"audience\":\"https://autobem-backend.com\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    return Ok(response.Content);
                }
            }

            return BadRequest();
        }
    }
}
