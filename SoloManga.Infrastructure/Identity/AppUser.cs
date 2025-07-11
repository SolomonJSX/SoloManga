using Microsoft.AspNetCore.Identity;
using SoloManga.Domain.Entities;

namespace SoloManga.Infrastructure.Identity;

public class AppUser : IdentityUser, IAppUser 
{
    public bool IsAdmin { get; }
    public string AvatarUrl { get; }
    
    public List<Bookmark> Bookmarks { get; } = new List<Bookmark>();
    public List<UserRating> Ratings { get; set; } = new();
}