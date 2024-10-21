namespace Ecommerce.Models
{
    public class RegisterUserDto
    {
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; } 
        public required string FirstName { get; set; }
        public required string LastName { get; set; } 
        public required string Address { get; set; } 
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    }
}
