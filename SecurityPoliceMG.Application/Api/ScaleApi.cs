using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using SecurityPoliceMG.Api.Base;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Domain.Entity.Enum;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Api;

[ApiController]
[Route("/api/scales")]
[EnableCors("LocalPolicy")]
public class ScaleApi(IScaleService service) : BaseController
{
    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost("{scaleId:guid}/register/{personId:guid}")]
    public IActionResult AddOnScale([FromRoute] Guid scaleId, [FromRoute] Guid personId)
    {
        ScaleDetailsResponseDto response = service.AddOnScale(scaleId, personId);
        return Created(response.Id.ToString(), response);
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost]
    public IActionResult CreateScale([FromBody] CreateScaleRequestDto requestDto)
    {
        ScaleDetailsResponseDto response = service.CreateScale(requestDto);
        return Created(response.Id.ToString(), response);
    }

    [Authorize]
    [HttpGet("{scaleId:guid}/report")]
    public IActionResult GenerateReport([FromRoute] Guid scaleId)
    {
        var pdfBytes = service.GenerateReport(scaleId, GetLoggedUserId()).GeneratePdf();

        return File(pdfBytes, "application/pdf", $"scale_report_{DateTime.UtcNow:dd/MM/yyyy HH:mm}.pdf");
    }

    [AllowAnonymous]
    [HttpGet("{scaleId:guid}/debug/report")]
    public IActionResult GenerateReportDebug([FromRoute] Guid scaleId)
    {
        var pdfBytes = service.GenerateReport(scaleId, Guid.Empty);

        pdfBytes.ShowInCompanion();

        return Ok("Opened archive on Companion Software");
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpGet]
    public IActionResult FindAll(
        [FromQuery] int? page,
        [FromQuery] int? pageSize,
        [FromQuery] string? sort,
        [FromQuery] string? orderTerm,
        [FromQuery] string? searchTerm)
    {
        var pageable = Pageable.Of(page, pageSize, sort, orderTerm, searchTerm);
        return Ok(service.FindAll(pageable));
    }
}