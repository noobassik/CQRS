using Application.Dtos;
using Application.Extensions;
using CQRS.Application.Data.DataBaseContext;
using CQRS.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Topics
{
    public class TopicsService(IApplicationDbContext dbContext,
        ILogger<TopicsService> logger) : ITopicsService
    {
        public Task<TopicResponseDto> CreateTopicAsync(Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TopicResponseDto> GetTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TopicResponseDto>> GetTopicsAsync()
        {
            var topics = await dbContext.Topics
                .ToListAsync();
            return topics.ToTopicResponseDtoList();
        }

        public Task<TopicResponseDto> UpdateTopicAsync(Guid id, Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
