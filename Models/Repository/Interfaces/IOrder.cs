using CurrencyExchange.Models.Dto.Orders;
using CurrencyExchange.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Interfaces
{
    public interface IOrder : IRepository<Order, long>
    {
        Task<long> GetNewOrderNum();
        Task<IEnumerable<Order>> GetOrderByStatus(Enum.Order.Status status);
        Task UpdateAdminOrder(long OrderId, string AdminDesctiption);
        Task<IEnumerable<Order>> GetOrderByUserId(long UserId, Models.Enum.Order.OrderType type);
    }
}
