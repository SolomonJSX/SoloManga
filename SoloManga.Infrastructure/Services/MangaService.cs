using SoloManga.Application.Interfaces;
using SoloManga.Domain.Entities;
using SoloManga.Infrastructure.Persistence;
using SoloManga.Application.DTOs.MangaDtos;


namespace SoloManga.Infrastructure.Services
{
    public class MangaService(AppDbContext dbContext) : IMangaService
    {
        public async Task<Manga> CreateMangaAsync(MangaCreateDto dto)
        {
            var manga = new Manga()
            {
                Title = dto.Title,
                Description = dto.Description,
                Author = dto.Author,
                Artist = dto.Artist,
                ReleaseDate = dto.ReleaseDate,
                Status = dto.Status,
                CoverImageUrl = dto.CoverImageUrl,
                LastUpdated = DateTime.UtcNow,
                Rating = 0
            };
            
            dbContext.Mangas.Add(manga);
            await dbContext.SaveChangesAsync();
            
            return manga;
        }
    }
}
