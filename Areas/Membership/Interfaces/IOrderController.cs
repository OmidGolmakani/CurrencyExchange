using CurrencyExchange.Models.Dto.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership.Interfaces
{
    public interface IOrderController : IController<CUOrderDto, long>
    {
        public Task<IActionResult> GetOrdersByStatus(Models.Enum.Order.Status status);
        public Task<IActionResult> Find(string dateFrom,string dateTo,Models.Enum.Order.OrderType type);
        public Task<IActionResult> GetOrderByUserId(long UserId, Models.Enum.Order.OrderType type);
    }
}
