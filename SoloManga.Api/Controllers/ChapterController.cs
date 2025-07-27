using Microsoft.AspNetCore.Mvc;
using SoloManga.Application.DTOs.MangaDtos;
using SoloManga.Application.Interfaces;
using SoloManga.Domain.Entities;

namespace SoloManga.Api.Controllers;

[ApiController]
[Route("api/chapters")]
public class ChapterController(IChapterService chapterService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateChapter([FromBody] ChapterCreateDto chapterDto)
    {
        var chapter = await chapterService.CreateChapterAsync(chapterDto);
        return Ok(chapter);
    }
    
    [HttpGet("manga/{mangaId}")]
    public async Task<IActionResult> GetChaptersByMangaId(int mangaId)
    {
        var chapters = await chapterService.GetChaptersByMangaIdAsync(mangaId);
        return Ok(chapters);
    }

    // GET: Получить конкретную главу по Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetChapterById(int id)
    {
        var chapter = await chapterService.GetByIdAsync(id);
        if (chapter == null) return NotFound();

        return Ok(chapter);
    }

    // DELETE: Удалить главу
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChapter(int id)
    {
        try
        {
            await chapterService.DeleteChapterAsync(id);
            return NoContent(); // 204
        }
        catch (Exception e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}