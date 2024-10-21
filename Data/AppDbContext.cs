using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce.Data
{
    // IdentityDbContext<User> manages the built-in Identity tables for authentication 
    // (e.g., AspNetUsers, AspNetRoles) while also allowing custom user properties 
    // from the User model (e.g., FirstName, LastName, Address) to be included 
    // in the AspNetUsers table alongside the default Identity properties (e.g., UserName, Email).
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderItem> OrderItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }
    }
}
