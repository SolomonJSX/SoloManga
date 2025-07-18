using SoloManga.Domain.Entities;

namespace SoloManga.Application.DTOs;

public class UserViewDto
{
    public int Id { get; set; }
    public string Username { get; set; } = "Чан";
    public string Email { get; set; } = null!;
    public string Role { get; set; } = "User";
    public string? AvatarUrl { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Bookmark> Bookmarks { get; set; }
    public List<UserRating> Ratings { get; set; }
    public List<Comment> Comments { get; set; }
}