namespace SoloManga.Domain.Entities;

public class Bookmark
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int MangaId { get; set; }
    public Manga Manga { get; set; }
    public int? LastReadChapterId { get; set; }
    public Chapter LastReadChapter { get; set; }
    public DateTime LastReadDate { get; set; }
    public BookmarkStatus Status { get; set; }
}

public enum BookmarkStatus
{
    PlanningToRead,
    Reading,
    OnHold,
    Dropped,
    Completed
}