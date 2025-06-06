using M1.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M1.Services;

namespace M1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _queueService;

        public QueueController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var message = await _queueService.ReceiveMessageAsync();
            if (message == String.Empty)
            {
                return NotFound("Message has hidden or does not exist");
            }
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult> Post(string message)
        {
            await _queueService.SendMessageAsync(message);
            return Ok();
        }
    }
}