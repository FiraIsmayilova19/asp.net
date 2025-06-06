using Microsoft.AspNetCore.Mvc;
using RabbitMqFanoutWebApi.Services;

namespace RabbitMqFanoutWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly RabbitMqProducerService _producer;

        public ProducerController(RabbitMqProducerService producer)
        {
            _producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            await _producer.SendMessageAsync(message);
            return Ok($"Message sent: {message}");
        }
    }
}
