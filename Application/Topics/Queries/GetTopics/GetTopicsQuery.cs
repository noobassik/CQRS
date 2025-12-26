namespace Application.Topics.Queries.GetTopics
{
    public record GetTopicsQuery : IQuery<GetTopicsResult>;

    public record GetTopicsResult(List<TopicResponseDto> Topics);
}
