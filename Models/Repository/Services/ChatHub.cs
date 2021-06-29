using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Services
{
    public class ChatHub : Hub
    {
        private readonly IHubContext<ChatHub> _hub;

        public ChatHub(IHubContext<ChatHub> hub)
        {
            this._hub = hub;
        }

        public async Task CurrencyChange(string user, string message)
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
