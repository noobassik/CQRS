using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class TopicExtensions
    {
        public static TopicResponseDto ToTopicResponseDto(this Topic topic)
        {
            return new TopicResponseDto(
                Id: topic.Id.Value,
                Title: topic.Title,
                Summary: topic.Summary,
                TopicType: topic.TopicType,
                Location: new LocationDto(
                    topic.Location.City,
                    topic.Location.Street),
                EventStart: topic.EventStart);
        }

        public static List<TopicResponseDto> ToTopicResponseDtoList(this List<Topic> topics)
        {
            return topics
                .Select(t => t.ToTopicResponseDto())
                .ToList();
        }
    }
}
