using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Services
{
    public class CurrencyExchangeHub : Hub
    {
        private readonly IHubContext<CurrencyExchangeHub> _hub;

        public CurrencyExchangeHub(IHubContext<CurrencyExchangeHub> hub)
        {
            this._hub = hub;
        }

        public async Task CurrencyChange(string user, string message)
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
