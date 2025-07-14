namespace SoloManga.Application.DTOs;

public record UploadCoverRequestDto(Stream FileStream, string FileName);