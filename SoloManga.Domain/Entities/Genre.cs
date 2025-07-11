﻿namespace SoloManga.Domain.Entities;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<Manga> Mangas { get; set; } = new List<Manga>();
}