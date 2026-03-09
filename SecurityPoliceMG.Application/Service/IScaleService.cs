using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.Service;

public interface IScaleService
{
    ScaleDetailsResponseDto CreateScale(Guid personId, CreateScaleRequestDto responseDto);

    Page<ScaleDetailsResponseDto> FindAll(Pageable pageable);
}