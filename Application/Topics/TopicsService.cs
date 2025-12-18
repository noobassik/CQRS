using CQRS.Application.Data.DataBaseContext;
using CQRS.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Topics
{
    public class TopicsService(IApplicationDbContext dbContext,
        ILogger<TopicsService> logger) : ITopicsService
    {
        public Task<Topic> CreateTopicAsync(Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTopicAsync(TopicId id)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetTopicAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Topic>> GetTopicsAsync()
        {
            var topics = await dbContext.Topics
                .ToListAsync();
            return topics;
        }

        public Task<Topic> UpdateTopicAsync(TopicId id, Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
