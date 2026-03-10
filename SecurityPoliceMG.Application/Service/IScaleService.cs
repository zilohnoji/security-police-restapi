using QuestPDF.Infrastructure;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.Service;

public interface IScaleService
{
    ScaleDetailsResponseDto AddOnScale(Guid scaleId, Guid personId);

    ScaleDetailsResponseDto CreateScale(CreateScaleRequestDto responseDto);

    Page<ScaleDetailsResponseDto> FindAll(Pageable pageable);

    IDocument GenerateReport(Guid scaleId, Guid loggedUserId);
}