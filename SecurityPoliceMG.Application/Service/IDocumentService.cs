using SecurityPoliceMG.Api.Dto.File.Request;
using SecurityPoliceMG.Api.Dto.File.Response;

namespace SecurityPoliceMG.Service;

public interface IDocumentService
{
    byte[] GetFile(string fileName);

    Task<FileDetailsResponseDto> SaveFile(UploadDocumentRequestDto requestDto);

    Task<List<FileDetailsResponseDto>> SaveMultipleFiles(UploadDocumentRequestDto[] requestDtos);
}