using SoloManga.Application.ResponseModel;
using SoloManga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoloManga.Application.DTOs;

namespace SoloManga.Application.Interfaces
{
    public interface IMangaService
    {
        Task<List<MangaViewDto>> GetAllMangasAsync();
        Task<MangaViewDto> GetMangaByIdAsync(int id);
        Task<List<MangaViewDto>> SearchMangasAsync(string query);
        Task<List<MangaViewDto>> GetMangasByAuthorAsync(string author);
        Task<List<MangaViewDto>> GetMangasByArtistAsync(string artist);
        Task<List<MangaViewDto>> GetMangasByStatusAsync(MangaStatus status);
        Task AddMangaAsync(MangaViewDto manga);
        Task UpdateMangaAsync(MangaViewDto manga);
        Task DeleteMangaAsync(int id);
    }
}
