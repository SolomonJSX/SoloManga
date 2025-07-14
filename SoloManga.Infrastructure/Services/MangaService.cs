using Microsoft.EntityFrameworkCore;
using SoloManga.Application.Interfaces;
using SoloManga.Application.ResponseModel;
using SoloManga.Domain.Entities;
using SoloManga.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloManga.Infrastructure.Services
{
    public class MangaService(AppDbContext dbContext) : IMangaService
    {
        public Task AddMangaAsync(MangaViewDto manga)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMangaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MangaViewDto>> GetAllMangasAsync()
        {
            return await dbContext.Mangas
                .OrderByDescending(m => m.LastUpdated)
                .Select(m => new MangaViewDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Author = m.Author,
                    Artist = m.Artist,
                    ReleaseDate = m.ReleaseDate,
                    LastUpdated = m.LastUpdated,
                    Status = m.Status,
                    ChaptersCount = m.Chapters.Count,
                    CoverImageUrl = m.CoverImageUrl,
                    Rating = m.Rating
                }).ToListAsync();
        }

        public async Task<MangaViewDto> GetMangaByIdAsync(int id)
        {
            return await dbContext.Mangas
                .Where(m => m.Id == id)
                .Select(m => new MangaViewDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Author = m.Author,
                    Artist = m.Artist,
                    ReleaseDate = m.ReleaseDate,
                    LastUpdated = m.LastUpdated,
                    Status = m.Status,
                    ChaptersCount = m.Chapters.Count,
                    CoverImageUrl = m.CoverImageUrl,
                    Rating = m.Rating
                }).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Manga with ID {id} not found.");
        }

        public Task<List<MangaViewDto>> GetMangasByArtistAsync(string artist)
        {
            return dbContext.Mangas
                .Where(m => m.Artist != null && m.Artist.Contains(artist, StringComparison.OrdinalIgnoreCase))
                .Select(m => new MangaViewDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Author = m.Author,
                    Artist = m.Artist,
                    ReleaseDate = m.ReleaseDate,
                    LastUpdated = m.LastUpdated,
                    Status = m.Status,
                    ChaptersCount = m.Chapters.Count,
                    CoverImageUrl = m.CoverImageUrl,
                    Rating = m.Rating
                }).ToListAsync();
        }

        public Task<List<MangaViewDto>> GetMangasByAuthorAsync(string author)
        {
            return dbContext.Mangas
                .Where(m => m.Author != null && m.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .Select(m => new MangaViewDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Author = m.Author,
                    Artist = m.Artist,
                    ReleaseDate = m.ReleaseDate,
                    LastUpdated = m.LastUpdated,
                    Status = m.Status,
                    ChaptersCount = m.Chapters.Count,
                    CoverImageUrl = m.CoverImageUrl,
                    Rating = m.Rating
                }).ToListAsync();
        }

        public Task<List<MangaViewDto>> GetMangasByStatusAsync(MangaStatus status)
        {
            return dbContext.Mangas
                .Where(m => m.Status == status)
                .Select(m => new MangaViewDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Author = m.Author,
                    Artist = m.Artist,
                    ReleaseDate = m.ReleaseDate,
                    LastUpdated = m.LastUpdated,
                    Status = m.Status,
                    ChaptersCount = m.Chapters.Count,
                    CoverImageUrl = m.CoverImageUrl,
                    Rating = m.Rating
                }).ToListAsync();
        }

        public Task<List<MangaViewDto>> SearchMangasAsync(string query)
        {
            return dbContext.Mangas
                .Where(m => m.Title != null && m.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(m => new MangaViewDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Author = m.Author,
                    Artist = m.Artist,
                    ReleaseDate = m.ReleaseDate,
                    LastUpdated = m.LastUpdated,
                    Status = m.Status,
                    ChaptersCount = m.Chapters.Count,
                    CoverImageUrl = m.CoverImageUrl,
                    Rating = m.Rating
                }).ToListAsync();
        }

        public Task UpdateMangaAsync(MangaViewDto manga)
        {
            return Task.Run(() =>
            {
                var existingManga = dbContext.Mangas.Find(manga.Id);
                if (existingManga == null)
                {
                    throw new KeyNotFoundException($"Manga with ID {manga.Id} not found.");
                }
                existingManga.Title = manga.Title;
                existingManga.Description = manga.Description;
                existingManga.Author = manga.Author;
                existingManga.Artist = manga.Artist;
                existingManga.ReleaseDate = manga.ReleaseDate;
                existingManga.LastUpdated = manga.LastUpdated;
                existingManga.Status = manga.Status;
                existingManga.CoverImageUrl = manga.CoverImageUrl;
                existingManga.Rating = manga.Rating;
                dbContext.SaveChanges();
            });
        }
    }
}
