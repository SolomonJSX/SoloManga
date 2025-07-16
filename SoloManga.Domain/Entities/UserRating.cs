namespace SoloManga.Domain.Entities;

public class UserRating
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int User { get; set; }
    public int MangaId { get; set; }
    public Manga Manga { get; set; } =  null!;
    public int Rating { get; set; } // Обычно от 1 до 10
    public DateTime RatingDate { get; set; }
}