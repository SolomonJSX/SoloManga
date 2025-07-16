using Microsoft.EntityFrameworkCore;
using SoloManga.Domain.Entities;

namespace SoloManga.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Manga> Mangas => Set<Manga>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRating> UserRatings => Set<UserRating>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<MangaGenre> MangaGenres => Set<MangaGenre>();
    public DbSet<Page> Pages => Set<Page>();
    public DbSet<Bookmark> Bookmarks => Set<Bookmark>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MangaGenre>()
            .HasKey(mg => new { mg.GenreId, mg.MangaId });
    }
}