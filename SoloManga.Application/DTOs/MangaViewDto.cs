using SoloManga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloManga.Application.ResponseModel
{
    public class MangaViewDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public MangaStatus Status { get; set; }
        public int ChaptersCount { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Rating { get; set; }
    }
}
