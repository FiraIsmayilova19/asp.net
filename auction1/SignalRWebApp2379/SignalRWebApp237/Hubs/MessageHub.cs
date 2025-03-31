using Microsoft.AspNetCore.SignalR;
using SignalRWebApp237.Services;
using System.Timers;

namespace SignalRWebApp237.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IFileService _fileService;
        private static System.Timers.Timer? _auctionTimer;
        private static string _lastBidder = "";

        public MessageHub(IFileService fileService)
        {
            _fileService = fileService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveConnectInfo", "User Connected");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.Others.SendAsync("ReceiveDisconnectInfo", "User Disconnected");
        }

        public async Task SendMessage(string message, double data)
        {
            _lastBidder = message;
            await Clients.All.SendAsync("ReceiveMessage", message, data);

            RestartAuctionTimer();
        }

        private void RestartAuctionTimer()
        {
            _auctionTimer?.Stop();
            _auctionTimer = new System.Timers.Timer(10000);
            _auctionTimer.Elapsed += async (sender, e) =>
            {
                await Clients.All.SendAsync("AuctionEnded", _lastBidder);
                _auctionTimer.Stop();
            };
            _auctionTimer.AutoReset = false;
            _auctionTimer.Start();
        }
    }
}
