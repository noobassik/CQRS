namespace Application.Topics.Commands.UpdateTopic
{
	public record UpdateTopicCommand(Guid id, UpdateTopicDto UpdateTopicDto) : ICommand<UpdateTopicResult>;
	
	public record UpdateTopicResult(TopicResponseDto Result);
}
