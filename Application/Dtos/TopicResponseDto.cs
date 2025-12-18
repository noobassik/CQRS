namespace Application.Dtos
{
    public record TopicResponseDto(
        Guid Id,
        string Title,
        string Summary,
        string TopicType,
        LocationDto Location,
        DateTime? EventStart
    );
}
