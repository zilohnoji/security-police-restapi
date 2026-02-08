namespace SecurityPoliceMG.Api.Dto.File.Request;

public class UploadMultipleDocumentsRequestDto
{
    public IFormFile[] Files { get; set; } = [];
}