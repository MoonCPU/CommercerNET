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

        public async Task<IdentityResult> RegisterUser(User user, string password)
        {
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
