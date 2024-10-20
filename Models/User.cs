using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    // By inheriting from IdentityUser, the custom User class automatically gains 
    // access to built-in Identity properties like UserName, Email, PasswordHash, etc., 
    // which are essential for authentication and user management in ASP.NET Identity.
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    }
}
