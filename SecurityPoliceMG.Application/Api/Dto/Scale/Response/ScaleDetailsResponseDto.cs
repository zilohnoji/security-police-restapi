using SecurityPoliceMG.Api.Dto.Builder.FluentBuilder.Response;

namespace SecurityPoliceMG.Api.Dto.Scale.Response;

public sealed class ScaleDetailsResponseDto
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime FinishedAt { get; set; }

    public string Description { get; set; }

    private ScaleDetailsResponseDto()
    {
    }

    public sealed class ScaleBuilder : IScaleDetailsResponseDtoBuilder
    {
        private readonly ScaleDetailsResponseDto _dto;

        private ScaleBuilder()
        {
            _dto = new ScaleDetailsResponseDto();
        }

        public ScaleDetailsResponseDto Build()
        {
            return _dto;
        }

        public static IScaleDetailsResponseDtoBuilder Builder()
        {
            return new ScaleBuilder();
        }

        public IScaleDetailsResponseDtoBuilder ScaleId(Guid scaleId)
        {
            _dto.Id = scaleId;
            return this;
        }

        public IScaleDetailsResponseDtoBuilder IsCompleted(bool isCompleted)
        {
            _dto.IsCompleted = isCompleted;
            return this;
        }

        public IScaleDetailsResponseDtoBuilder CreatedAt(DateTime createdAt)
        {
            _dto.CreatedAt = createdAt;
            return this;
        }

        public IScaleDetailsResponseDtoBuilder StartsAt(DateTime startsAt)
        {
            _dto.StartsAt = startsAt;
            return this;
        }

        public IScaleDetailsResponseDtoBuilder FinishedAt(DateTime finishedAt)
        {
            _dto.FinishedAt = finishedAt;
            return this;
        }

        public IScaleDetailsResponseDtoBuilder Description(string description)
        {
            _dto.Description = description;
            return this;
        }
    }
}