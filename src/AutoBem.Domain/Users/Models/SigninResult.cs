
namespace AutoBem.Domain.Users.Models
{
    public class SigninResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }
    }
}
