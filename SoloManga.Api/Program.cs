using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoloManga.Application.Interfaces;
using SoloManga.Infrastructure.Identity;
using SoloManga.Infrastructure.Persistence;
using SoloManga.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//DB
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Using services
builder.Services.AddScoped<IMangaService, MangaService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
/*----------------------------------------------------------------*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();