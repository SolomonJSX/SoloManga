using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SoloManga.Domain.Entities;

[Index(nameof(Username))]
[Index(nameof(Email))]
public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "Чан";
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = "User";
    public string? AvatarUrl { get; set; }
    public string? BannerUrl { get; set; }
    public string? Bio { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    public List<Bookmark> Bookmarks { get; set; } = new();
    public List<UserRating> Ratings { get; set; } = new List<UserRating>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}