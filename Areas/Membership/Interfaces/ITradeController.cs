using CurrencyExchange.Models.Dto.Trades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership.Interfaces
{
    public interface ITradeController : IController<CUTradeDto, long>
    {
        public Task<IActionResult> Find(string dateFrom, string dateTo);
        public Task<IActionResult> GetTradeByUserId(long UserId);
    }
}
