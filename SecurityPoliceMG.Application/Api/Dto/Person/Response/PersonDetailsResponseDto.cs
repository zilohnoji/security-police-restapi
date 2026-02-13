using SecurityPoliceMG.Api.Dto.Scale.Response;
using SecurityPoliceMG.Application.Builder.Dto.Response;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class PersonDetailsResponseDto
{
    public Guid Id { get; set; }

    public ProfileResponse Profile { get; set; } = new ProfileResponse();

    public AddressDetailsResponseDto Address { get; set; } = AddressDetailsResponseDto.Empty;

    public ICollection<ScaleDetailsResponseDto> Scales { get; set; } = new List<ScaleDetailsResponseDto>();

    private PersonDetailsResponseDto()
    {
    }

    public sealed class PersonDetailsBuilder : IPersonDetailsResponseDtoFluentBuilder
    {
        private readonly PersonDetailsResponseDto _dto;

        private PersonDetailsBuilder()
        {
            _dto = new PersonDetailsResponseDto();
        }

        public static IPersonDetailsResponseDtoFluentBuilder Builder()
        {
            return new PersonDetailsBuilder();
        }

        public PersonDetailsResponseDto Build()
        {
            return _dto;
        }

        public IPersonDetailsResponseDtoFluentBuilder Id(Guid id)
        {
            _dto.Id = id;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Name(string name)
        {
            _dto.Profile.Name = name;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder BirthDate(DateOnly birthDate)
        {
            _dto.Profile.BirthDate = birthDate;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Gender(string gender)
        {
            _dto.Profile.Gender = gender;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder MotherName(string motherName)
        {
            _dto.Profile.MotherName = motherName;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder DaddyName(string daddyName)
        {
            _dto.Profile.DaddyName = daddyName;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Photo(PhotoDetailsResponseDto photo)
        {
            _dto.Profile.Photo = photo;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Address(AddressDetailsResponseDto address)
        {
            _dto.Address = address;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Scales(List<ScaleDetailsResponseDto> scale)
        {
            _dto.Scales = scale;
            return this;
        }
    }
}

public sealed class ProfileResponse
{
    public string Name { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string MotherName { get; set; } = string.Empty;

    public string DaddyName { get; set; } = string.Empty;

    public PhotoDetailsResponseDto Photo { get; set; } = PhotoDetailsResponseDto.Empty;
}