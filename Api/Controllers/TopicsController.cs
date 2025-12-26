using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> GetTopics()
        {
            return Results.Ok(await mediator.Send(new GetTopicsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetTopic(Guid id)
        {
            return Results.Ok(await mediator.Send(new GetTopicQuery(id)));
        }

        [HttpPost]
        public async Task<IResult> CreateTopic(CreateTopicDto dto)
        {
            var response = await mediator.Send(new CreateTopicCommand(dto));
            return Results.Created($"/topics/{response.Result.Id}", response.Result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TopicResponseDto>> UpdateTopic(Guid id, [FromBody] UpdateTopicDto dto)
        {
            return Ok(null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TopicResponseDto>> DeleteTopic(Guid id)
        {
            return Ok(null);
        }
    }
}
