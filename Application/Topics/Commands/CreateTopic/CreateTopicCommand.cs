namespace Application.Topics.Commands.CreateTopic
{
    public record CreateTopicCommand(CreateTopicDto TopicDto) : ICommand<CreateTopicResult>;

    public record CreateTopicResult(TopicResponseDto Result);
}
