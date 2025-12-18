namespace Application.Dtos
{
    public record UpdateTopicDto(
        string Title,
        string Summary,
        string TopicType,
        LocationDto Location,
        DateTime EventStart
    );
}
