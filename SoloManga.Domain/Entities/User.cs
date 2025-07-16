

using System.ComponentModel.DataAnnotations;

namespace SoloManga.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "Чан";
    public string? AvatarUrl { get; set; }
    public DateTime RegistrationDate { get; set; }

    public List<Bookmark> Bookmarks { get; set; } = new();
    public List<UserRating> Ratings { get; set; } = new List<UserRating>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}