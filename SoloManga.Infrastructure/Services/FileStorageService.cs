using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SoloManga.Infrastructure.Services;

public class FileStorageService(IWebHostEnvironment env)
{
    public async Task<string> UploadFilesAsync(IFormFile file, string pathName)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Файл не передан или он пуст.");

        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };

        if (!allowedExtensions.Contains(ext))
            throw new NotSupportedException($"Расширение файла {ext} не поддерживается.");

        var fileName = $"{Guid.NewGuid()}{ext}";
        var fullPath = Path.Combine(env.WebRootPath, pathName, fileName);

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);

        // Возвращаем относительный путь
        return Path.Combine("/", pathName, fileName).Replace("\\", "/");
    }
}