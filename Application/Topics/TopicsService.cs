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

        public Task DeleteTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Topic>> GetTopicsAsync()
        {
            var topics = await dbContext.Topics
                .ToListAsync();
            return topics;
        }

        public Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
