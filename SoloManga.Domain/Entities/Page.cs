namespace SoloManga.Domain.Entities;

public class Page
{
    public int Id { get; set; }
    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; }
    public int PageNumber { get; set; }
    public string ImageUrl { get; set; } = null!;
}