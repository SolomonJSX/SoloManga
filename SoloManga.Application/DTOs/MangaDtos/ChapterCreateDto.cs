namespace SoloManga.Application.DTOs.MangaDtos;

public class ChapterCreateDto
{
    public int MangaId { get; set; }
    public string? Title { get; set; }
    public int ChapterNumber { get; set; }
    public int? VolumeNumber { get; set; }
    public DateTime ReleaseDate { get; set; }
}