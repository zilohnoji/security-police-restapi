using QuestPDF.Infrastructure;
using SecurityPoliceMG.Api.Dto.Scale.Request;
using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Repository.Base;
using SecurityPoliceMG.EFCore.Repository.Impl;
using SecurityPoliceMG.Service.Impl.ScaleModule.Report;
using SecurityPoliceMG.Service.Validator.ScaleValidator.AddOnScaleValidation;
using SecurityPoliceMG.Util;

namespace SecurityPoliceMG.Service.Impl.ScaleModule;

public class ScaleServiceImpl(
    ScaleRepositoryImpl scaleRepository,
    PersonRepositoryImpl personRepository,
    IEmailService emailService,
    IEnumerable<IScaleAddOnScaleValidator> addOnScaleValidators)
    : IScaleService
{
    public ScaleDetailsResponseDto AddOnScale(Guid scaleId, Guid personId)
    {
        var personEntity = personRepository.FindById(personId);
        var scaleEntity = scaleRepository.FindById(scaleId);

        foreach (var validator in addOnScaleValidators)
        {
            validator.Validate(new ScaleAddOnScaleArgs(scaleEntity, personEntity));
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

        return GenerateScaleReport.GenerateReport(scale, loggedUserId);
    }
}