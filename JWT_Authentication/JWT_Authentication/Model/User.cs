using Microsoft.AspNetCore.Identity;

namespace JWT_Authentication.Model
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
