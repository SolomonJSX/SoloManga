using Microsoft.EntityFrameworkCore;
using SoloManga.Application.DTOs.MangaDtos;
using SoloManga.Application.Interfaces;
using SoloManga.Domain.Entities;
using SoloManga.Infrastructure.Persistence;

namespace SoloManga.Infrastructure.Services;

public class ChapterService(AppDbContext dbContext) : IChapterService
{
    public async Task<Chapter> CreateChapterAsync(ChapterCreateDto dto)
    {
        var chapter = new Chapter()
        {
            MangaId = dto.MangaId,
            Title = dto.Title,
            ChapterNumber = dto.ChapterNumber,
            VolumeNumber = dto.VolumeNumber,
            ReleaseDate = dto.ReleaseDate,
            PageCount = 0
        };

        dbContext.Chapters.Add(chapter);
        await dbContext.SaveChangesAsync();
        
        return chapter;
    }

    public async Task<List<Chapter>> GetChaptersByMangaIdAsync(int mangaId)
    {
        return await dbContext.Chapters
            .Where(c => c.MangaId == mangaId)
            .OrderBy(c => c.ChapterNumber)
            .Include(c => c.Pages)
            .ToListAsync();
    }

    public async Task<Chapter?> GetByIdAsync(int id)
    {
        return await dbContext.Chapters
            .Include(c => c.Pages)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task DeleteChapterAsync(int id)
    {
        var chapter = await dbContext.Chapters
            .Include(c => c.Pages)
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if (chapter == null) throw new Exception("Chapter not found");
        
        dbContext.Pages.RemoveRange(chapter.Pages);
        dbContext.Chapters.Remove(chapter);
        await dbContext.SaveChangesAsync();
    }
}