using System.Text.Json.Serialization;

namespace SecurityPoliceMG.Api.Dto.File.Response;

public class FileDetailsResponseDto
{
    public string Name { get; private set; } = string.Empty;

    public string Size { get; private set; } = string.Empty;

    [JsonPropertyName("document_type")] public string DocType { get; private set; } = string.Empty;

    public string Url { get; private set; } = string.Empty;

    private FileDetailsResponseDto()
    {
    }

    private FileDetailsResponseDto(string name, string size, string docType, string url)
    {
        Name = name;
        Size = size;
        DocType = docType;
        Url = url;
    }

    public static FileDetailsResponseDto Of(IFormFile file, string url)
    {
        var fileName = Path.GetFileName(file.FileName);
        var fileSize = file.Length.ToString();
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

        return new FileDetailsResponseDto(fileName, fileSize, fileExtension, url);
    }
}