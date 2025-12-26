namespace Application.Topics.Queries.GetTopic
{
    public record GetTopicQuery(Guid id) : IQuery<GetTopicResult>;

    public record GetTopicResult(TopicResponseDto Topic);
}
