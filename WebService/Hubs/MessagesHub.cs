using Microsoft.AspNetCore.SignalR;

namespace WebService.Hubs
{
    public class MessagesHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
