namespace SoloManga.Domain.Entities;

public class Chapter
{
    public int Id { get; set; }

    public int MangaId { get; set; }
    public Manga Manga { get; set; } = null!;

    public string? Title { get; set; }
    public int ChapterNumber { get; set; }
    public int? VolumeNumber { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int PagesCount { get; set; }
    public List<Page> Pages { get; set; } = new();
}