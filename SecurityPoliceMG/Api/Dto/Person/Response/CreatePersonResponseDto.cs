using SecurityPoliceMG.Application.Builder.Dto.Response;

namespace SecurityPoliceMG.Api.Dto.Person.Response;

public sealed class CreatePersonResponseDto
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Gender { get; private set; }
    public string MotherName { get; private set; }
    public string DaddyName { get; private set; }

    private CreatePersonResponseDto()
    {
        Id = Guid.Empty;
        Name = string.Empty;
        BirthDate = DateTime.Now;
        Gender = string.Empty;
        MotherName = string.Empty;
        DaddyName = string.Empty;
    }

    public sealed class PersonDtoBuilder : ICreatePersonResponseDtoFluentBuilder
    {
        private CreatePersonResponseDto _dto;

        private PersonDtoBuilder()
        {
            this._dto = new CreatePersonResponseDto();
        }

        public static PersonDtoBuilder Builder()
        {
            return new PersonDtoBuilder();
        }

        public CreatePersonResponseDto Build()
        {
            return _dto;
        }

        public ICreatePersonResponseDtoFluentBuilder Id(Guid id)
        {
            _dto.Id = id;
            return this;
        }

        public ICreatePersonResponseDtoFluentBuilder Name(string name)
        {
            _dto.Name = name;
            return this;
        }

        public ICreatePersonResponseDtoFluentBuilder BirthDate(DateTime birthDate)
        {
            _dto.BirthDate = birthDate;
            return this;
        }

        public ICreatePersonResponseDtoFluentBuilder Gender(string gender)
        {
            _dto.Gender = gender;
            return this;
        }

        public ICreatePersonResponseDtoFluentBuilder MotherName(string motherName)
        {
            _dto.MotherName = motherName;
            return this;
        }

        public ICreatePersonResponseDtoFluentBuilder DaddyName(string daddyName)
        {
            _dto.DaddyName = daddyName;
            return this;
        }
    }
}