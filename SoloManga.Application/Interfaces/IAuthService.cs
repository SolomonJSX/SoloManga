using SoloManga.Application.DTOs;

namespace SoloManga.Application.Interfaces;

public interface IAuthService
{
    Task<string> Register(RegisterDto dto);
    Task<string> Login(LoginDto dto);
}