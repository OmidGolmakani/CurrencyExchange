using CurrencyExchange.Models.Dto.CurrencyExchangeHub;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CurrencyExchange.Models.Repository.Services
{
    public class CurrencyExchangeHub : Hub
    {
        private readonly IHubContext<CurrencyExchangeHub> _hub;

        public CurrencyExchangeHub(IHubContext<CurrencyExchangeHub> hub)
        {
            this._hub = hub;
        }

        public async Task CurrencyChange(CurrencyChangeDto currencyChange)
        {
            await _hub.Clients.All.SendAsync("CurrencyChange", JsonConvert.SerializeObject(currencyChange));
        }
    }
}
