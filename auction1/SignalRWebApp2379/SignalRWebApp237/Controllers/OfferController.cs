using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRWebApp237.Hubs;
using SignalRWebApp237.Services;

namespace SignalRWebApp237.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IHubContext<MessageHub> _hubContext;

        public OfferController(IFileService fileService, IHubContext<MessageHub> hubContext)
        {
            _fileService = fileService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<double> Get()
        {
            var data = await _fileService.Read();
            return data;
        }

        [HttpGet("Increase")]
        public async Task<ActionResult> Increase(double data, string username)
        {
            var newBid = (await _fileService.Read()) + data;
            await _fileService.Write(newBid);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", username, newBid);

            return Ok(newBid);
        }
    }
}
