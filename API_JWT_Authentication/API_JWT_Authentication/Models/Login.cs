using System.ComponentModel.DataAnnotations;

namespace API_JWT_Authentication.Models
{
    public class Login
    {
        [Key]
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
