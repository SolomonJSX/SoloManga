using SoloManga.Application.DTOs;

namespace SoloManga.Application.Interfaces;

public interface IUserService
{
    Task<string> ChangeAvatarAsync(int userId, UploadCoverRequestDto request);
}