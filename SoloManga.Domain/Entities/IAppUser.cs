namespace SoloManga.Domain.Entities;

public interface IAppUser
{
    string Id { get; }
    string? UserName { get; }
    string? Email { get; }
    string AvatarUrl { get; }
    bool IsAdmin { get; }
}