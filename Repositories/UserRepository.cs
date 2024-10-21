using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // The password is passed separately to ensure security. 
        // ASP.NET Core Identity handles hashing the password through the UserManager.
        // Passwords are not stored directly in the User entity. Instead, the UserManager hashes the password 
        // and stores the hash in the PasswordHash property of IdentityUser. 
        // By using CreateAsync(user, password), we let Identity handle secure password hashing and storage.
        //the Identity framework automatically associates the 'password' parameter with the password-handling process.
        public async Task<IdentityResult> RegisterUser(RegisterUserDto userDto, string password)
        {
            // Map RegisterUserDto to User
            var user = new User
            {
                UserName = userDto.Email,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address,
                PhoneNumber = userDto.PhoneNumber,
                DateJoined = DateTime.UtcNow
            };

            // Create the user
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> LoginUser(string email, string password)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return SignInResult.Failed;
            }

            // Password SignIn
            return await _signInManager.PasswordSignInAsync(user, password, false, false);
        }
    }
}
