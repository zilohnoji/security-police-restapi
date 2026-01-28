using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.Api.Mapper;
using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Repository;
using SecurityPoliceMG.Service;

namespace SecurityPoliceMG.Domain.Service;

public class PersonServiceImpl : IPersonService
{
    private readonly IRepository<Person> _repository;

    public PersonServiceImpl(IRepository<Person> repository)
    {
        _repository = repository;
    }

    public CreatePersonResponseDto Create(CreatePersonRequestDto requestDto)
    {
        Person entity = _repository.Create(PersonMapper.ToEntity(requestDto));
        return PersonMapper.ToDto(entity);
    }

    public List<CreatePersonResponseDto> FindAll()
    {
        return _repository.FindAll().Select(dto => PersonMapper.ToDto(dto)).ToList();
    }
}