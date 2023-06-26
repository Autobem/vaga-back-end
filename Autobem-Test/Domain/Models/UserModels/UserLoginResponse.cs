namespace Domain.Models.UserModels;

public class UserLoginResponse
{
    public string access_token { get; set; }
    public string expires_in { get; set; }
    public string token_type { get; set; }
}