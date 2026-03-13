using SecurityPoliceMG.Api.Dto.Address.Response;
using SecurityPoliceMG.Api.Dto.Builder.FluentBuilder.Response;
using SecurityPoliceMG.Api.Dto.Photo.Response;
using SecurityPoliceMG.Api.Dto.Scale.Response;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class PersonDetailsResponseDto
{
    public Guid Id { get; set; }

    public ProfileResponse Profile { get; set; }

    public AddressDetailsResponseDto Address { get; set; }

    public ICollection<ScaleDetailsResponseDto> Scales { get; set; } = new List<ScaleDetailsResponseDto>();

    private PersonDetailsResponseDto()
    {
    }

    public sealed class PersonDetailsBuilder : IPersonDetailsResponseDtoBuilder
    {
        private readonly PersonDetailsResponseDto _dto;

        private PersonDetailsBuilder()
        {
            _dto = new PersonDetailsResponseDto();
        }

        public static IPersonDetailsResponseDtoBuilder Builder()
        {
            return new PersonDetailsBuilder();
        }

        public PersonDetailsResponseDto Build()
        {
            return _dto;
        }

        public IPersonDetailsResponseDtoBuilder Id(Guid id)
        {
            _dto.Id = id;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder Name(string name)
        {
            _dto.Profile.Name = name;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder BirthDate(DateOnly birthDate)
        {
            _dto.Profile.BirthDate = birthDate;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder Gender(string gender)
        {
            _dto.Profile.Gender = gender;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder MotherName(string motherName)
        {
            _dto.Profile.MotherName = motherName;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder DaddyName(string daddyName)
        {
            _dto.Profile.DaddyName = daddyName;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder Photo(PhotoDetailsResponseDto photo)
        {
            _dto.Profile.Photo = photo;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder Address(AddressDetailsResponseDto address)
        {
            _dto.Address = address;
            return this;
        }

        public IPersonDetailsResponseDtoBuilder Scales(List<ScaleDetailsResponseDto> scale)
        {
            _dto.Scales = scale;
            return this;
        }
    }
}

public sealed class ProfileResponse
{
    public string Name { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Gender { get; set; }

    public string MotherName { get; set; }

    public string DaddyName { get; set; }

    public PhotoDetailsResponseDto Photo { get; set; }
}