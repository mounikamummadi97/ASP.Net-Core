using System.ComponentModel.DataAnnotations;

namespace API_JWT_Authentication.Models
{
    public class AuthenticatedResponse
    {
        [Key]
        public string? Token { get; set; }
    }
}
