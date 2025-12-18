using Application.Topics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(ITopicsService topicsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTopics()
        {
            return Ok(await topicsService.GetTopicsAsync());
        }
    }
}
