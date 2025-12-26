namespace Application.Topics.Queries.GetTopics
{
    public class GetTopicsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTopicsQuery, GetTopicsResult>
    {
        public async Task<GetTopicsResult> Handle(GetTopicsQuery request, CancellationToken cancellationToken)
        {
            var topics = await dbContext.Topics
                .Where(t => !t.IsDeleted)
                .ToListAsync(cancellationToken);

            return new GetTopicsResult(topics.ToTopicResponseDtoList());
        }
    }
}
