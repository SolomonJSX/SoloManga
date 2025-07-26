using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;
using SoloManga.Infrastructure.Persistence;

namespace SoloManga.Infrastructure.Services;

public class UserService(AppDbContext context, IWebHostEnvironment env, FileStorageService fileStorageService)
{
    public async Task<string> ChangeAvatarAsync(int userId, IFormFile file)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        
        if (user == null)
            throw new Exception("User not found");

        if (!string.IsNullOrEmpty(user.AvatarUrl))
        {
            var oldAvatarPath = Path.Combine(env.ContentRootPath, user.AvatarUrl.TrimStart('/'));
            if (File.Exists(oldAvatarPath))
                File.Delete(oldAvatarPath);
        }

        var newAvatarUrl = await fileStorageService.UploadCoverAsync(file, "uploads/avatars");
        user.AvatarUrl = newAvatarUrl;
        await context.SaveChangesAsync();
        return newAvatarUrl;
    }
    
    public async Task<string> ChangeBannerAsync(int userId, IFormFile file)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        
        if (user == null)
            throw new Exception("User not found");

        if (!string.IsNullOrEmpty(user.BannerUrl))
        {
            var oldBannerPath = Path.Combine(env.ContentRootPath, user.BannerUrl.TrimStart('/'));
            if (File.Exists(oldBannerPath))
                File.Delete(oldBannerPath);
        }

        var newBannerUrl = await fileStorageService.UploadCoverAsync(file, "uploads/banners");
        user.BannerUrl = newBannerUrl;
        await context.SaveChangesAsync();
        return newBannerUrl;
    }

    public async Task<UserViewDto> UpdateUserAsync(UserEditDto dto, int userId)
    {
        var  user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        
        if (user == null)
            throw new Exception("User not found");
        
        if (!string.IsNullOrWhiteSpace(dto.Username))
            user.Username = dto.Username;
        
        user.Bio = dto.Bio;
        
        await context.SaveChangesAsync();

        return new UserViewDto()
        {
            Id = user.Id,
            Username = user.Username,
            Bio = user.Bio,
            AvatarUrl = user.AvatarUrl,
            RegistrationDate = user.RegistrationDate,
            Email = user.Email,
            Role = user.Role,
            BannerUrl = user.BannerUrl
        };
    }
}