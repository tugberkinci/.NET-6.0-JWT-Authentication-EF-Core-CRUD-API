using System.Text.Json.Serialization;

namespace JwtAuthentication.Models
{
    public class UserModel
    {
        public string? Name { get; set; } 
        public string? Surname { get; set; }
        public string? MailAddress { get; set; } 
        public string? Password { get; set; }

        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
    }
}
