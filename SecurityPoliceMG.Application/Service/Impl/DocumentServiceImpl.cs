using SecurityPoliceMG.Api.Dto.File.Request;
using SecurityPoliceMG.Api.Dto.File.Response;

namespace SecurityPoliceMG.Service.Impl;

public class DocumentServiceImpl : IDocumentService
{
    private readonly string _basePath;
    private readonly IHttpContextAccessor _context;
    private static readonly string[] AllowedExtensions = [".zip", ".rar", ".pdf", ".jpg", ".jpeg", ".txt"];

    public DocumentServiceImpl(IHttpContextAccessor context)
    {
        _context = context;
        _basePath = $"{Environment.CurrentDirectory}/Files";
        if (!Directory.Exists(_basePath))
        {
            Directory.CreateDirectory(_basePath);
        }
    }

    public byte[] GetFile(string fileName)
    {
        var filePath = Path.Combine(_basePath, fileName) ?? throw new ArgumentException("File not found");
        return File.ReadAllBytes(filePath);
    }

    public async Task<FileDetailsResponseDto> SaveFile(UploadDocumentRequestDto requestDto)
    {
        var fileExtension = Path.GetExtension(requestDto.File.FileName).ToLowerInvariant();

        if (!AllowedExtensions.Contains(fileExtension))
        {
            throw new ArgumentException("Não existe essa extensao");
        }

        var destination = Path.Combine(_basePath, Path.GetFileName(requestDto.File.FileName));
        var baseUrl = $"{_context.HttpContext.Request.Scheme}://{_context.HttpContext.Request.Host}";
        var fileUrl = $"{baseUrl}/api/documents/download/{Path.GetFileName(requestDto.File.FileName)}";

        await using var stream = new FileStream(destination, FileMode.Create);

        await requestDto.File.CopyToAsync(stream);
        return FileDetailsResponseDto.Of(requestDto.File, fileUrl);
    }
}