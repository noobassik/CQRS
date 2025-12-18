using CQRS.Domain.ValueObjects;

namespace Application.Topics
{
    public interface ITopicsService
    {
        Task<List<Topic>> GetTopicsAsync();
        Task<Topic> GetTopicAsync(Guid id);
        Task<Topic> CreateTopicAsync(Topic topicRequestDto);
        Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto);
        Task DeleteTopicAsync(Guid id);
    }
}
