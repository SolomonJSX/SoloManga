using System.ComponentModel.DataAnnotations;
using SoloManga.Domain.Entities;

namespace SoloManga.Application.DTOs.MangaDtos;

public class MangaCreateDto
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

    public string? CoverImageUrl { get; set; }
}