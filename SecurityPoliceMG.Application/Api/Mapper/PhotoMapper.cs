using SecurityPoliceMG.Api.Dto.Person.Request;
using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class PhotoMapper
{
    public static Photo ToEntity(CreatePhotoRequestDto dto, Person person)
    {
        return Photo.Of(dto.Bucket, dto.Hash, person);
    }

    public static PhotoDetailsResponseDto ToDto(Photo entity)
    {
        return PhotoDetailsResponseDto.Of(entity.Bucket, entity.Hash);
    }
}