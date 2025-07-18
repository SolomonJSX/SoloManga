using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;
using SoloManga.Infrastructure.Persistence;

namespace SoloManga.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService, AppDbContext context) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            var token = await authService.Register(dto);

            return Ok(new
            {
                token
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            var token = await authService.Login(dto);

            return Ok(new
            {
                token
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("me")]
    public async Task<ActionResult<UserViewDto>> GetCurrentUser()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userId)) throw new UnauthorizedAccessException();
            
            var currentUser = await context.Users
                .Include(u => u.Bookmarks)
                .Include(u => u.Comments)
                .Include(u => u.Ratings)
                .AsNoTracking().FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            
            if (currentUser == null) throw new UnauthorizedAccessException();
            
            return Ok(new UserViewDto()
            {
                Id = currentUser.Id,
                Email = currentUser.Email,
                AvatarUrl = currentUser.AvatarUrl,
                Bookmarks = currentUser.Bookmarks,
                Comments = currentUser.Comments,
                Ratings = currentUser.Ratings,
                RegistrationDate = currentUser.RegistrationDate,
                Role = currentUser.Role,
                Username = currentUser.Username
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}