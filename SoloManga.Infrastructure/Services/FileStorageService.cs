using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;

namespace SoloManga.Infrastructure.Services;

public class FileStorageService(IWebHostEnvironment env)
{
    public async Task<string> UploadCoverAsync(IFormFile file, string pathName)
    {
        var ext = Path.GetExtension(file.FileName);
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
        
        if (!allowedExtensions.Contains(ext))
            throw new NotSupportedException($"The file extension {ext} is not supported.");
        
        var fileName = $"{Guid.NewGuid()}{ext}";
        
        var path = Path.Combine(env.WebRootPath, pathName, fileName);
        
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        
        await using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
        
        return $"/{pathName}/{fileName}";
    }
}