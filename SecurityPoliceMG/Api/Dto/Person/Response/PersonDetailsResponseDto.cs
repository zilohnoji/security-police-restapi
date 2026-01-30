using System.Text.Json.Serialization;
using SecurityPoliceMG.Application.Builder.Dto.Response;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class PersonDetailsResponseDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Gender { get; private set; }

    [JsonPropertyName("birth_date")] public DateTime BirthDate { get; private set; }

    [JsonPropertyName("mother_name")] public string MotherName { get; private set; }

    [JsonPropertyName("daddy_name")] public string DaddyName { get; private set; }

    public PhotoDetailsResponseDto Photo { get; private set; }

    public AddressDetailsResponseDto Address { get; private set; }

    private PersonDetailsResponseDto()
    {
        Id = Guid.Empty;
        Name = string.Empty;
        Gender = string.Empty;
        BirthDate = DateTime.Now;
        MotherName = string.Empty;
        DaddyName = string.Empty;
        Photo = PhotoDetailsResponseDto.Empty;
        Address = AddressDetailsResponseDto.Empty;
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
            _dto.Name = name;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder BirthDate(DateTime birthDate)
        {
            _dto.BirthDate = birthDate;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Gender(string gender)
        {
            _dto.Gender = gender;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder MotherName(string motherName)
        {
            _dto.MotherName = motherName;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder DaddyName(string daddyName)
        {
            _dto.DaddyName = daddyName;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Photo(PhotoDetailsResponseDto photo)
        {
            _dto.Photo = photo;
            return this;
        }

        public IPersonDetailsResponseDtoFluentBuilder Address(AddressDetailsResponseDto address)
        {
            _dto.Address = address;
            return this;
        }
    }
}