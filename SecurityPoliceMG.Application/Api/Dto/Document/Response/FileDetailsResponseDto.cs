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

    public static FileDetailsResponseDto Of(string name, string size, string docType, string url)
    {
        return new FileDetailsResponseDto(name, size, docType, url);
    }
}