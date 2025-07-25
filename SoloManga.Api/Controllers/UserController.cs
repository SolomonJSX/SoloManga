using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloManga.Api.Extensions;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;
using SoloManga.Infrastructure.Persistence;
using SoloManga.Infrastructure.Services;

namespace SoloManga.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(UserService userService, AppDbContext context, IWebHostEnvironment env) : ControllerBase
{
    [Authorize]
    [HttpPost("avatar")]
    public async Task<IActionResult> UploadAvatar([FromForm] IFormFile file)
    {
        var userId = User.GetUserId();
        var avatarUrl = await userService.ChangeAvatarAsync(userId, file);
        return Ok(new { avatarUrl });
    }
    
    [Authorize]
    [HttpDelete("avatar")]
    public async Task<IActionResult> DeleteAvatar()
    {
        var userId = User.GetUserId(); // реализуй получение userId
        var user = await context.Users.FindAsync(userId);
        if (user == null) return NotFound();

        if (!string.IsNullOrEmpty(user.AvatarUrl))
        {
            var filePath = Path.Combine(env.WebRootPath, user.AvatarUrl.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            user.AvatarUrl = null;
            await context.SaveChangesAsync();
        }

        return NoContent();
    }

    
    [Authorize]
    [HttpPost("banner")]
    public async Task<IActionResult> UploadBanner([FromForm] IFormFile file)
    {
        var userId = User.GetUserId();
        var avatarUrl = await userService.ChangeBannerAsync(userId, file);
        return Ok(new { avatarUrl });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserEditDto user)
    {
        
    }
    
    [HttpGet("me")]
    public async Task<ActionResult<UserViewDto>> GetCurrentUser()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userId)) throw new UnauthorizedAccessException();
            
            var currentUser = await context.Users
                .AsNoTracking().FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            
            if (currentUser == null) throw new UnauthorizedAccessException();
            
            return Ok(new UserViewDto()
            {
                Id = currentUser.Id,
                Email = currentUser.Email,
                AvatarUrl = currentUser.AvatarUrl,
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