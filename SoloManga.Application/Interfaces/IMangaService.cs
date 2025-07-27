using SoloManga.Application.ResponseModel;
using SoloManga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoloManga.Application.DTOs;
using SoloManga.Application.DTOs.MangaDtos;

namespace SoloManga.Application.Interfaces
{
    public interface IMangaService
    {
        Task<Manga> CreateMangaAsync(MangaCreateDto dto);
    }
}
