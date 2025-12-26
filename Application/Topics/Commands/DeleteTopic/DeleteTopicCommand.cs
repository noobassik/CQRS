namespace Application.Topics.Commands.DeleteTopic
{
    public record DeleteTopicCommand(Guid TopicId) : ICommand<DeleteTopicResult>;
    
    public record DeleteTopicResult(bool isSuccess);
}
