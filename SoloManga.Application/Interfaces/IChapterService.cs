using SoloManga.Application.DTOs.MangaDtos;
using SoloManga.Domain.Entities;

namespace SoloManga.Application.Interfaces;

public interface IChapterService
{
    Task<Chapter> CreateChapterAsync(ChapterCreateDto dto);
    Task<List<Chapter>> GetChaptersByMangaIdAsync(int mangaId);
    Task<Chapter?> GetByIdAsync(int id);
    Task DeleteChapterAsync(int id);
}