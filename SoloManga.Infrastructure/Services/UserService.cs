using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;
using SoloManga.Infrastructure.Persistence;

namespace SoloManga.Infrastructure.Services;

public class UserService(AppDbContext context, IWebHostEnvironment env, IFileStorageService fileStorageService) : IUserService
{
    public async Task<string> ChangeAvatarAsync(int userId, UploadCoverRequestDto request)
    {
        var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);
        
        if (user == null)
            throw new Exception("User not found");

        if (!string.IsNullOrEmpty(user.AvatarUrl))
        {
            var oldAvatarPath = Path.Combine(env.ContentRootPath, user.AvatarUrl.TrimStart('/'));
            if (File.Exists(oldAvatarPath))
                File.Delete(oldAvatarPath);
        }

        var newAvatarUrl = await fileStorageService.UploadCoverAsync(request, "uploads/avatars");
        user.AvatarUrl = newAvatarUrl;
        await context.SaveChangesAsync();
        return newAvatarUrl;
    }
}