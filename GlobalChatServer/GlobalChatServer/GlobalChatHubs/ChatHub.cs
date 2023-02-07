using GlobalChatServer.Model;
using Microsoft.AspNetCore.SignalR;

namespace GlobalChatServer.GlobalChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveNewMessage", message);
        }
    }
}
