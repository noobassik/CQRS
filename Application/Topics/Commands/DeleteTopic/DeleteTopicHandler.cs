namespace Application.Topics.Commands.DeleteTopic
{
    public class DeleteTopicHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteTopicCommand, DeleteTopicResult>
    {
        public async Task<DeleteTopicResult> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            var topicId = TopicId.Of(request.TopicId);

            var topic = await dbContext.Topics.FindAsync([topicId], cancellationToken);

            if (topic is null || topic.IsDeleted)
            {
                throw new TopicNotFoundException(request.TopicId);
            }

            topic.IsDeleted = true;
            topic.DeletedAt = DateTimeOffset.UtcNow;

            await dbContext.SaveChangesAsync(CancellationToken.None);

            return new DeleteTopicResult(true);
        }
    }
}
