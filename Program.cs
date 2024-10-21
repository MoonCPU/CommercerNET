using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("UserDb")
);

// AddIdentity<User, IdentityRole>() sets up ASP.NET Identity with the custom User model,
// including both default Identity properties (e.g., UserName, Email) and custom properties.
// IdentityRole is used to manage user roles, enabling role-based authorization.
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// For every HTTP request, when IUserRepository is injected,
// a new instance of UserRepository is created and used for that request's lifetime.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddAuthentication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("MyCors");

app.MapControllers();

app.Run();


//Here's how the database, models and DbContext will work together
/*
 * 1. User Model Creation:
 *    We create a custom User class that inherits from IdentityUser to leverage built-in properties 
 *    essential for authentication, such as UserName, Email, and PasswordHash. Additionally, we define 
 *    custom properties like FirstName, LastName, Address, and DateJoined to store additional user information.
 *
 * 2. DbContext Definition:
 *    We define AppDbContext, inheriting from IdentityDbContext<User>. This class manages the built-in 
 *    Identity tables that handle authentication-related data. By specifying our custom User class as the 
 *    generic type parameter, we ensure that these tables include both the default properties and our 
 *    custom properties.
 *
 * 3. Database Registration in Program.cs:
 *    We register the AppDbContext with the dependency injection container, using an in-memory database 
 *    for development and testing. We also call AddIdentity<User, IdentityRole>() to configure ASP.NET 
 *    Identity with our custom User model and IdentityRole for role management. This setup allows us 
 *    to store user-related data in the AppDbContext, making it accessible for authentication and authorization.
 */