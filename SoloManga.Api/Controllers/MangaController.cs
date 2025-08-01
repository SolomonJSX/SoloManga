using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoloManga.Api.Requests;
using SoloManga.Application.DTOs.MangaDtos;
using SoloManga.Application.Interfaces;
using SoloManga.Domain.Entities;
using SoloManga.Infrastructure.Services;

namespace SoloManga.Api.Controllers;

[ApiController]
[Route("api/manga")]
public class MangaController(IMangaService mangaService, FileStorageService fileStorage) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateManga(MangaCreateRequest mangaRequest)
    {
        string? imageUrl = null;

        if (mangaRequest.CoverImage != null)
        {
            imageUrl = await fileStorage.UploadFilesAsync(mangaRequest.CoverImage, "uploads/mangaCovers");
        }

        var dto = new MangaCreateDto()
        {
            Title = mangaRequest.Title,
            Description = mangaRequest.Description,
            Author = mangaRequest.Author,
            Artist = mangaRequest.Artist,
            ReleaseDate = mangaRequest.ReleaseDate,
            Status = mangaRequest.Status,
            CoverImageUrl = imageUrl,
        };
        
        var createdManga = await mangaService.CreateMangaAsync(dto);
        
        return Ok(createdManga);
    }
}