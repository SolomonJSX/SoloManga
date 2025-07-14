using Microsoft.AspNetCore.Hosting;
using SoloManga.Application.DTOs;
using SoloManga.Application.Interfaces;

namespace SoloManga.Infrastructure.Services;

public class FileStorageService(IWebHostEnvironment env) : IFileStorageService
{
    public async Task<string> UploadCoverAsync(UploadCoverRequestDto request)
    {
        var ext = Path.GetExtension(request.FileName);
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
        
        if (!allowedExtensions.Contains(ext))
            throw new NotSupportedException($"The file extension {ext} is not supported.");
        
        var fileName = $"{Guid.NewGuid()}{ext}";
        
        var path = Path.Combine(env.ContentRootPath, "covers", fileName);
        
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        
        await using var stream = new FileStream(path, FileMode.Create);
        await request.FileStream.CopyToAsync(stream);
        
        return $"/covers/{fileName}";
    }
}