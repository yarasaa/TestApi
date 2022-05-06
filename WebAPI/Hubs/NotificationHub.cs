using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task TriggerNotification()
        {
            await Clients.All.SendAsync("triggerNotification",Context.ConnectionId);
        }
    }
}
