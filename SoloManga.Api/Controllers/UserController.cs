using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloManga.Api.Extensions;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;
using SoloManga.Infrastructure.Persistence;

namespace SoloManga.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService, AppDbContext context) : ControllerBase
{
    [Authorize]
    [HttpPost("avatar")]
    public async Task<IActionResult> UploadAvatar([FromForm] UploadCoverRequestDto dto)
    {
        var userId = User.GetUserId();
        var avatarUrl = await userService.ChangeAvatarAsync(userId, dto);
        return Ok(new { avatarUrl });
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