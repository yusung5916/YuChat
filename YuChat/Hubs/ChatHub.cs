using Microsoft.AspNetCore.SignalR;

namespace YuChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
        }
    }
}
