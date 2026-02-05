using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class Person : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public DateOnly BirthDate { get; private set; }

    public string Gender { get; private set; } = string.Empty;

    public string MotherName { get; private set; } = string.Empty;

    public string DaddyName { get; private set; } = string.Empty;

    public Guid AddressId { get; private set; } = Guid.Empty;

    public Address Address { get; private set; } = Address.Empty;

    public Photo Photo { get; private set; } = Photo.Empty;

    public Guid UserId { get; private set; } = Guid.Empty;

    public User User { get; private set; } = User.Empty;

    public ICollection<PersonScale> PersonScales { get; private set; } = new List<PersonScale>();

    public static readonly Person Empty = new Person();

    public sealed class PersonBuilder : IPersonBuilder
    {
        private readonly Person _entity;

        private PersonBuilder()
        {
            _entity = new Person();
        }

        public Person Build()
        {
            return _entity;
        }

        public static IPersonBuilder Builder()
        {
            return new PersonBuilder();
        }

        public IPersonBuilder Name(string name)
        {
            _entity.Name = name;
            return this;
        }

        public IPersonBuilder BirthDate(DateOnly birthDate)
        {
            _entity.BirthDate = birthDate;
            return this;
        }

        public IPersonBuilder Gender(string gender)
        {
            _entity.Gender = gender;
            return this;
        }

        public IPersonBuilder MotherName(string motherName)
        {
            _entity.MotherName = motherName;
            return this;
        }

        public IPersonBuilder DaddyName(string daddyName)
        {
            _entity.DaddyName = daddyName;
            return this;
        }

        public IPersonBuilder Address(Address address)
        {
            _entity.AddressId = address.Id;
            _entity.Address = address;
            return this;
        }

        public IPersonBuilder User(User user)
        {
            _entity.UserId = user.Id;
            _entity.User = user;
            return this;
        }
    }

    public void DefinePhoto(Photo photo)
    {
        Photo = photo;
    }

    public void DefineUser(User user)
    {
        User = user;
    }

    public void DefineAddress(Address address)
    {
        Address = address;
    }
}