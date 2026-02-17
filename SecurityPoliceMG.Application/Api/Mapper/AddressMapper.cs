using SecurityPoliceMG.Api.Dto.Address.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class AddressMapper
{
    public static Address ToEntity(CreateAddressRequestDto dto, City city)
    {
        return Address.AddressBuilder.Builder()
            .Number(dto.Number)
            .City(city)
            .Street(dto.Street)
            .Neighborhood(dto.Neighborhood)
            .PatioType(dto.PatioType)
            .Build();
    }
    
    public static Address ToEntity(CreateAddressRequestDto dto)
    {
        return Address.AddressBuilder.Builder()
            .Number(dto.Number)
            .City(CityMapper.ToEntity(dto.City))
            .Street(dto.Street)
            .Neighborhood(dto.Neighborhood)
            .PatioType(dto.PatioType)
            .Build();
    }


    public static AddressDetailsResponseDto ToDto(Address entity)
    {
        return AddressDetailsResponseDto.AddressDetailsBuilder.Builder()
            .Number(entity.Number)
            .City(CityMapper.ToDto(entity.City))
            .Street(entity.Street)
            .Neighborhood(entity.Neighborhood)
            .PatioType(entity.PatioType)
            .Build();
    }
}