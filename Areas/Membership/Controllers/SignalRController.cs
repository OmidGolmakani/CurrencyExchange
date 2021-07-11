using CurrencyExchange.Controllers;
using CurrencyExchange.Models.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership
{
    public class SignalRController : BaseController<SignalRController>
    {
        private readonly CurrencyExchangeHub _chatHub;

        public SignalRController(CurrencyExchangeHub chatHub)
        {
            this._chatHub = chatHub;
        }
        [HttpPost("SendTestMessage")]
        public async Task<IActionResult> SendTestMessage()
        {
            await _chatHub.CurrencyChange(new Models.Dto.CurrencyExchangeHub.CurrencyChangeDto() { CurrencyId = 1 });
            return Ok("Message is sent");
        }
    }
}
