using GlobalChatServer.Model;
using Microsoft.AspNetCore.SignalR;

namespace GlobalChatServer.GlobalChatHubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            _logger.LogInformation($"New connection: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation($"Connection: {Context.ConnectionId} disconnected");
            return base.OnDisconnectedAsync(exception);
        }

        [HubMethodName("CheckStatus")]
        public async Task CheckStatus()
        {
            _logger.LogInformation("Checking status");
            await Clients.Caller.SendAsync("CheckStatusResponse", true);
        }

        [HubMethodName("SendMessage")]
        public async Task SendMessageAsync(ChatMessage message)
        {
            _logger.LogInformation("Sending message");
            await Clients.All.SendAsync("ReceiveNewMessage", message);
        }
    }
}
