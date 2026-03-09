using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.EFCore.Repository.Impl;

namespace SecurityPoliceMG.Service.Impl;

public class ScaleServiceImpl(ScaleRepositoryImpl scaleRepository, PersonRepositoryImpl personRepository)
    : IScaleService
{
    public ScaleDetailsResponseDto CreateScale(Guid personId, CreateScaleRequestDto requestDto)
    {
        var personEntity = personRepository.FindById(personId);

        if (personEntity is null) throw new ArgumentException($"Person de ID {personId} não encontrada!");

        var scaleEntity = ScaleMapper.ToEntity(requestDto, personEntity);

        scaleEntity.PersonScales.Add(PersonScale.Of(scaleEntity, personEntity, 0));

        scaleRepository.Create(scaleEntity);

        return ScaleMapper.ToDto(scaleEntity);
    }

    public Page<ScaleDetailsResponseDto> FindAll(Pageable pageable)
    {
        return ScaleMapper.ToPageDto(scaleRepository.FindAllInclude(pageable));
    }
}