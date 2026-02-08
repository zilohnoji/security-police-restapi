using SecurityPoliceMG.Api.Dto.File.Request;
using SecurityPoliceMG.Api.Dto.File.Response;
using SecurityPoliceMG.Domain.Entity.Enum;

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
        throw new NotImplementedException();
    }

    public async Task<FileDetailsResponseDto> SaveFile(UploadDocumentRequestDto requestDto)
    {
        var s = requestDto.Extension;
        if (!AllowedExtensions.Contains(requestDto.Extension))
        {
            throw new ArgumentException("Não existe essa extensao");
        }

        string destination = Path.Combine(_basePath, requestDto.FileName);
        string baseUrl = $"{_context.HttpContext.Request.Scheme}://{_context.HttpContext.Request.Host}";
        string fileUrl = $"{baseUrl}/api/documents/download/{requestDto.FileName}";

        using var stream = new FileStream(destination, FileMode.Create);

        await requestDto.File.CopyToAsync(stream);
        return FileDetailsResponseDto.Of(requestDto.FileName, requestDto.Size, requestDto.Extension, fileUrl);
    }

    public Task<List<FileDetailsResponseDto>> SaveMultipleFiles(UploadDocumentRequestDto[] requestDtos)
    {
        throw new NotImplementedException();
    }
}