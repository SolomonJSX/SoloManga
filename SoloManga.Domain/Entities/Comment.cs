namespace SoloManga.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; }

    public int? MangaId { get; set; } // Комментарий к манге (опционально)
    public Manga Manga { get; set; }

    public int? ChapterId { get; set; } // Или к главе (опционально)
    public Chapter Chapter { get; set; }
}