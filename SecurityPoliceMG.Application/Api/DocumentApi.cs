using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SecurityPoliceMG.Api.Dto.File.Request;
using SecurityPoliceMG.Api.Dto.File.Response;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("api/documents")]
[EnableCors("LocalPolicy")]
public sealed class DocumentApi(IDocumentService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadDocument([FromForm] UploadDocumentRequestDto requestDto)
    {
        var fileDetail = await service.SaveFile(requestDto);
        return Ok(fileDetail);
    }

    [HttpGet("download/{fileName}")]
    public IActionResult DownloadDocument([FromRoute] string fileName)
    {
        byte[] response = service.GetFile(fileName);
        string contentType = "application/octet-stream";
        return File(response, contentType, fileName);
    }
}