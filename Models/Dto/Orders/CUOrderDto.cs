using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Orders
{
    public class CUOrderDto
    {
        public Nullable<long> Id { get; set; }
        public string OrderSolarDate { get; set; }
        private DateTime _OrderDate;
        [JsonIgnore]
        public DateTime OrderDate
        {
            get
            {
                return (Helper.PersionDate.GetMiladi(OrderSolarDate, OrderTime) ?? DateTime.Now);
            }
            set
            {
                _OrderDate = value;
            }
        }
        public string OrderTime { get; set; }
        [JsonIgnore]
        public long OrderNum { get; set; }
        public long UserId { get; set; }
        public int CurrencyId { get; set; }
        public int Quantity { get; set; }
        public decimal InstantPrice { get; set; }
        public decimal CurrencyPrice { get; set; }
        [JsonIgnore]
        [DefaultValue(Models.Enum.Order.Status.AwaitingConfirmation)]
        public byte Status { get; set; }
        public string Description { get; set; }
    }
}
