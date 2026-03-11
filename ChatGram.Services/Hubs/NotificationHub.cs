using Microsoft.AspNetCore.SignalR;

namespace ChatGram.web.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification()
        {
            await Clients.All.SendAsync("ReceiveNotification");
        }
    }
}