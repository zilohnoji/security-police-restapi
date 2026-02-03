using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class CityMapper
{
    public static City ToEntity(CreateCityRequestDto dto)
    {
        return City.Of(dto.Name, dto.Uf);
    }

    public static CityDetailsResponseDto ToDto(City entity)
    {
        return CityDetailsResponseDto.Of(entity.Name, entity.Uf);
    }
}