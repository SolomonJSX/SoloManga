using System.ComponentModel.DataAnnotations;
using SoloManga.Domain.Entities;

namespace SoloManga.Api.Requests;

public class MangaCreateRequest
{
    [Required]
    public string Title { get; set; } = null!;
    
    public string? Description { get; set; }
    public string? Author { get; set; }
    public string? Artist { get; set; }
    
    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public MangaStatus Status { get; set; }

    public IFormFile? CoverImage { get; set; }
}