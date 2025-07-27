using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloManga.Domain.Entities;
using SoloManga.Infrastructure.Persistence;
using SoloManga.Infrastructure.Services;

namespace SoloManga.Api.Controllers;

[ApiController]
[Route("api/pages")]
public class PageController(FileStorageService fileStorage, AppDbContext dbContext) : ControllerBase
{
    [HttpPost("{chapterId}")]
    public async Task<IActionResult> UploadPages(int chapterId, [FromForm] List<IFormFile> files)
    {
        var chapter = await dbContext.Chapters
            .Include(c => c.Pages)
            .FirstOrDefaultAsync(c => c.Id == chapterId);
        if (chapter == null) return NotFound();
        int pageNumber = chapter.Pages.Count + 1;

        foreach (var file in files)
        {
            var url = await fileStorage.UploadFilesAsync(file, "uploads/pages");
            
            chapter.Pages.Add(new Page()
            {
                PageNumber = pageNumber++,
                ImageUrl = url
            });
        }
        
        chapter.PageCount = chapter.Pages.Count;
        await dbContext.SaveChangesAsync();

        return Ok(chapter.Pages);
    }

    [HttpDelete("{pageId}")]
    public async Task<IActionResult> DeletePage(int pageId)
    {
        var page = await dbContext.Pages.FindAsync(pageId);
        if (page == null) return NotFound();
        
        dbContext.Pages.Remove(page);
        await dbContext.SaveChangesAsync();

        return Ok();
    }
}