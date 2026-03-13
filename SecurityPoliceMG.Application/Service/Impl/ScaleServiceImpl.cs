using QuestPDF.Infrastructure;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.EFCore.Repository.Impl;
using SecurityPoliceMG.Service.Impl.Email;
using SecurityPoliceMG.Service.Impl.Report.Config;
using SecurityPoliceMG.Util;

namespace SecurityPoliceMG.Service.Impl;

public class ScaleServiceImpl(
    ScaleRepositoryImpl scaleRepository,
    PersonRepositoryImpl personRepository,
    IEmailService emailService)
    : IScaleService
{
    public ScaleDetailsResponseDto AddOnScale(Guid scaleId, Guid personId)
    {
        var personEntity = personRepository.FindById(personId);
        var scaleEntity = scaleRepository.FindById(scaleId);

        if (scaleEntity is null)
        {
            throw new ArgumentException($"A escala de ID {scaleId} não existe");
        }

        if (personEntity is null)
            throw new ArgumentException($"Person de ID {personId} não encontrada!");

        var startDate = scaleEntity.StartsAt;
        var finishDate = scaleEntity.FinishedAt;

        var t2 = personEntity.PersonScales.FirstOrDefault(s =>
            (s.Scale.StartsAt <= startDate &&
             s.Scale.FinishedAt >= finishDate) ||
            (s.Scale.StartsAt >= startDate &&
             s.Scale.FinishedAt <= finishDate)
        );

        if (t2 is not null)
        {
            throw new ArgumentException(
                $"Já existe uma escala nesse período de tempo para o usuário de ID {personId}");
        }

        scaleEntity.PersonScales.Add(PersonScale.Of(scaleEntity, personEntity, 0));

        scaleRepository.Update(scaleEntity);

        emailService.PersonRegisterOnScale(personEntity.User.Email, scaleEntity);

        return ScaleMapper.ToDto(scaleEntity);
    }

    public ScaleDetailsResponseDto CreateScale(CreateScaleRequestDto requestDto)
    {
        var startDate = DateParser.ParseDateTime(requestDto.StartsAt);
        var finishDate = DateParser.ParseDateTime(requestDto.FinishedAt);

        if (startDate < DateTime.UtcNow)
        {
            throw new ArgumentException("A data de início precisa ser maior que a data atual!!");
        }

        if (startDate > finishDate)
        {
            throw new ArgumentException("A data de início precisa ser maior que a data final!!");
        }

        var scaleEntity = ScaleMapper.ToEntity(requestDto);

        scaleRepository.Create(scaleEntity);

        return ScaleMapper.ToDto(scaleEntity);
    }

    public Page<ScaleDetailsResponseDto> FindAll(Pageable pageable)
    {
        return ScaleMapper.ToPageDto(scaleRepository.FindAllInclude(pageable));
    }

    public IDocument GenerateReport(Guid scaleId, Guid loggedUserId)
    {
        var scale = scaleRepository.FindById(scaleId);

        if (scale is null)
        {
            throw new ArgumentException($"Scale não encontrada com o ID {scaleId}");
        }

        return ScaleReportHelper.GenerateReport(scale, loggedUserId);
    }
}