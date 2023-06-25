using Domain.Contracts.Service;
using Domain.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IPasswordService _passwordService;
    private readonly HttpClient _httpClient;
    private readonly string _authEndpoint;
    private readonly string _authRequestBody;

    public AuthController(
        IUserService userService,
        IPasswordService passwordService,
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _userService = userService;
        _passwordService = passwordService;
        _httpClient = httpClient;
        _authEndpoint = configuration["Auth0:AuthEndpoint"] ?? throw new ArgumentException(nameof(_authEndpoint));
        _authRequestBody = configuration["Auth0:AuthRequestBody"] ?? throw new ArgumentException(nameof(_authRequestBody));
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLogin userLogin)
    {
        var user = await _userService.GetUserLogin(userLogin.Email);
        if (user is null)
            return NotFound("Email or Password don't match");

        var passwordHash = _passwordService.HashPassword(userLogin.Password, user.PasswordSalt);
        if (passwordHash == user.Password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _authEndpoint);

            request.Content = new StringContent(_authRequestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                var content = JsonConvert.DeserializeObject<UserLoginResponse>(await response.Content.ReadAsStringAsync());
                return Ok(content);
            }
        }
        return NotFound("Email or Password don't match");
    }
}