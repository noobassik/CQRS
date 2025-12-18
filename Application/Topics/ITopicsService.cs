using CQRS.Domain.ValueObjects;

namespace Application.Topics
{
    public interface ITopicsService
    {
        Task<List<Topic>> GetTopicsAsync();
        Task<Topic> GetTopicAsync();
        Task<Topic> CreateTopicAsync(Topic topicRequestDto);
        Task<Topic> UpdateTopicAsync(TopicId id, Topic topicRequestDto);
        Task DeleteTopicAsync(TopicId id);
    }
}
