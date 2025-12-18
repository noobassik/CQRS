using Application.Dtos;
using Application.Exceptions;
using Application.Extensions;
using CQRS.Application.Data.DataBaseContext;
using CQRS.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Topics
{
    public class TopicsService(IApplicationDbContext dbContext,
        ILogger<TopicsService> logger) : ITopicsService
    {
        public async Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto dto)
        {
            var topic = Topic.Create(
                TopicId.Of(Guid.NewGuid()),
                dto.Title,
                dto.EventStart,
                dto.Summary,
                dto.TopicType,
                Location.Of(dto.Location.City, dto.Location.Street));

            dbContext.Topics.Add(topic);

            await dbContext.SaveChangesAsync(CancellationToken.None);

            return topic.ToTopicResponseDto();
        }

        public Task DeleteTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TopicResponseDto> GetTopicAsync(Guid id)
        {
            var topicId = TopicId.Of(id);
            var result = await dbContext.Topics.FindAsync([topicId]);

            if (result is null)
            {
                throw new TopicNotFoundException(id);
            }

            return result.ToTopicResponseDto();
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
