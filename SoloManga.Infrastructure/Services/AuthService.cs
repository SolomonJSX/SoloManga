using Microsoft.EntityFrameworkCore;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;
using SoloManga.Domain.Entities;
using SoloManga.Infrastructure.Persistence;

namespace SoloManga.Infrastructure.Services;

public class AuthService(AppDbContext context, JwtService jwtService) : IAuthService
{
    public async Task<string> Register(RegisterDto dto)
    {
        if (await context.Users.AnyAsync(u => u.Email == dto.Email))
            throw new Exception("Email is already registered");

        User user;

        if (!context.Users.Any())
        {
            user = new User()
            {
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Admin"
            };
        }
        else
        {
            user = new User()
            {
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"
            };
        }
        
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        var token = jwtService.GenerateToken(user.Id, user.Email, user.Role);

        return token;
    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == dto.Login || u.Email == dto.Login);
        
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid login or password");
        
        var token = jwtService.GenerateToken(user.Id, user.Email, user.Role);
        
        return token;
    }
}