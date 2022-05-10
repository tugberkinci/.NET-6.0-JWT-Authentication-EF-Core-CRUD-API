using JwtAuthentication.Entities;

namespace JwtAuthentication.Models;


public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string MailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        Name= user.Name;
        Surname = user.Surname;
        MailAddress = user.MailAddress;
        Password = user.Password;
        CreatedAt = user.CreatedAt;
        Token = token;
    }
}