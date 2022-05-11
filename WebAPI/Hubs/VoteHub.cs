using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    public class VoteHub : Hub
    {
        public async Task SendMessageAsync()
        {
           await Clients.All.SendAsync("receiveMessage", "Data Değişti");
        }
    }
}
