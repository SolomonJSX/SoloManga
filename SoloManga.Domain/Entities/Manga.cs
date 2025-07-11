namespace SoloManga.Domain.Entities;

public class Manga
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    public string? Artist { get; set; }
    public DateTime ReleaseDate { get; set; }
    public MangaStatus Status { get; set; }
    public int ChaptersCount { get; set; }
    public string? CoverImageUrl { get; set; }
    public List<Genre> Genres { get; set; } = new List<Genre>();
    public List<Chapter> Chapters { get; set; } = new List<Chapter>();
    public decimal Rating { get; set; }
}

public enum MangaStatus
{
    Ongoing,
    Completed,
    Hiatus,
    Canceled
}