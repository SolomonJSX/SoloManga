using SoloManga.Application.DTOs;

namespace SoloManga.Application.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadCoverAsync(UploadCoverRequestDto request, string pathName);
}