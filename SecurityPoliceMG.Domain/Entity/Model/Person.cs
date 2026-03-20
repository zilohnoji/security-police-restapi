using SecurityPoliceMG.Domain.Entity.Builder.FluentBuilder;

namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class Person : BaseEntity
{
    public string Name { get; private set; }

    public DateOnly BirthDate { get; private set; }

    public string Gender { get; private set; }

    public string MotherName { get; private set; }

    public string DaddyName { get; private set; }

    public Guid AddressId { get; private set; }

    public Address Address { get; private set; }

    public Guid UserId { get; private set; }

    public User User { get; private set; }

    public ICollection<PersonScale> PersonScales { get; private set; } = new List<PersonScale>();

    public ICollection<Request> SentRequests { get; private set; } = new List<Request>();

    public ICollection<Request> ReceiveRequests { get; private set; } = new List<Request>();

    private Person()
    {
    }

    public sealed class PersonBuilder : IPersonBuilder
    {
        private readonly Person _entity;

        private PersonBuilder(Person? entity = null)
        {
            if (entity is not null)
            {
                _entity = entity;
                return;
            }

            _entity = new Person();
        }

        public Person Build()
        {
            return _entity;
        }

        public static IPersonBuilder Builder(Person? entity = null)
        {
            return new PersonBuilder(entity);
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

        public IPersonBuilder AddressId(Guid addressId)
        {
            _entity.AddressId = addressId;
            return this;
        }

        public IPersonBuilder UserId(Guid userId)
        {
            _entity.UserId = userId;
            return this;
        }
    }
}