using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(User user, string password);
        Task<SignInResult> LoginUser(string email, string password);
    }
}
