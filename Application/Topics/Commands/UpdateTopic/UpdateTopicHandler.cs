namespace Application.Topics.Commands.UpdateTopic
{
	public class UpdateTopicHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTopicCommand, UpdateTopicResult>
	{

		public async Task<UpdateTopicResult> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
		{
			TopicId topicId = TopicId.Of(request.id);

			var topic = await dbContext.Topics.FindAsync([topicId]);

			if (topic is null || topic.IsDeleted)
			{
				throw new TopicNotFoundException(request.id);
			}

			topic.Update(
				request.UpdateTopicDto.Title,
				request.UpdateTopicDto.Summary,
				request.UpdateTopicDto.TopicType,
				request.UpdateTopicDto.EventStart,
				request.UpdateTopicDto.Location.City,
				request.UpdateTopicDto.Location.Street
			);

			await dbContext.SaveChangesAsync(CancellationToken.None);

			return new UpdateTopicResult(topic.ToTopicResponseDto());
		}
	}
}
