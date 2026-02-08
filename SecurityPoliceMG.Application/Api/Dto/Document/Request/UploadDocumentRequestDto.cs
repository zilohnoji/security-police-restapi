namespace SecurityPoliceMG.Api.Dto.File.Request;

public class UploadDocumentRequestDto
{
    public IFormFile File { get; set; }

    public string FileName => Path.GetFileName(File.FileName);
    
    public string Extension => Path.GetExtension(File.FileName).ToLowerInvariant();
    
    public string Size => File.Length.ToString();
}