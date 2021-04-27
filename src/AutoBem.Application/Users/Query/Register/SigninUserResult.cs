using AutoBem.Domain.Users.Models;
using System.Text.Json.Serialization;

namespace AutoBem.Application.Users.Query.Register
{
    public class SigninUserResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }

        [JsonConstructor]
        public SigninUserResult()
        {

        }
        public SigninUserResult(SigninResult result)
        {
            IsSuccess = result.IsSuccess;
            Message = result.Message;
            Token = result.Token;
        }

    }
}
