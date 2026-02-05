using SecurityPoliceMG.Application.Api.Dto.Builder.Dto.Response;

namespace SecurityPoliceMG.Api.Dto.Scale.Response;

public sealed class ScaleDetailsResponseDto
{
    public Guid ScaleId { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime FinishedAt { get; set; }
    public string Description { get; set; } = string.Empty;

    public static readonly ScaleDetailsResponseDto Empty = new ScaleDetailsResponseDto();

    private ScaleDetailsResponseDto()
    {
    }

    public sealed class ScaleBuilder : IScaleDetailsResponseDtoFluentBuilder
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

        public static IScaleDetailsResponseDtoFluentBuilder Builder()
        {
            return new ScaleBuilder();
        }

        public IScaleDetailsResponseDtoFluentBuilder ScaleId(Guid scaleId)
        {
            _dto.ScaleId = scaleId;
            return this;
        }

        public IScaleDetailsResponseDtoFluentBuilder IsCompleted(bool isCompleted)
        {
            _dto.IsCompleted = isCompleted;
            return this;
        }

        public IScaleDetailsResponseDtoFluentBuilder CreatedAt(DateTime createdAt)
        {
            _dto.CreatedAt = createdAt;
            return this;
        }

        public IScaleDetailsResponseDtoFluentBuilder StartsAt(DateTime startsAt)
        {
            _dto.StartsAt = startsAt;
            return this;
        }

        public IScaleDetailsResponseDtoFluentBuilder FinishedAt(DateTime finishedAt)
        {
            _dto.FinishedAt = finishedAt;
            return this;
        }

        public IScaleDetailsResponseDtoFluentBuilder Description(string description)
        {
            _dto.Description = description;
            return this;
        }
    }
}