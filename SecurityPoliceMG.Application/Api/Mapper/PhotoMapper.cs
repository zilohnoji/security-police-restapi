using SecurityPoliceMG.Api.Dto.Person.Response;
using SecurityPoliceMG.Api.Dto.Photo.Request;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Api.Mapper;

public static class PhotoMapper
{
    public static Photo ToEntity(CreatePhotoRequestDto dto)
    {
        return Photo.Of(dto.Bucket, dto.Hash);
    }

    public static PhotoDetailsResponseDto ToDto(Photo entity)
    {
        return PhotoDetailsResponseDto.Of(entity.Bucket, entity.Hash);
    }
}