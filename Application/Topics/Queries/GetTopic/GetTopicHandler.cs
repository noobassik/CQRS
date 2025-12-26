namespace Application.Topics.Queries.GetTopic
{
    public record GetTopicHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTopicQuery, GetTopicResult>
    {
        public async Task<GetTopicResult> Handle(GetTopicQuery request, CancellationToken cancellationToken)
        {
            var topicId = TopicId.Of(request.id);
            var result = await dbContext.Topics.FindAsync([topicId], cancellationToken);

            if (result is null || result.IsDeleted)
            {
                throw new TopicNotFoundException(request.id);
            }

            return new GetTopicResult(result.ToTopicResponseDto());
        }
    }
}
