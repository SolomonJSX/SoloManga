namespace SoloManga.Domain.Entities;

public class UserRating
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!; // Ссылка на пользователя ASP.NET Identity
    public int MangaId { get; set; }
    public Manga Manga { get; set; } =  null!;
    public int Rating { get; set; } // Обычно от 1 до 10
    public DateTime RatingDate { get; set; }
}