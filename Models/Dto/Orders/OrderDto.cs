using CurrencyExchange.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Orders
{
    public class OrderDto
    {
        public long Id { get; set; }
        public string OrderSolarDate
        {
            get
            {
                return OrderDate.ToShamsi(false);
            }
        }
        [JsonIgnore]
        public DateTime OrderDate { get; set; }
        public string OrderTime
        {
            get
            {
                return OrderDate.ToString("HH:mm:ss");
            }
        }
        [JsonIgnore]
        public long OrderNum { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int Quantity { get; set; }
        public decimal InstantPrice { get; set; }
        public decimal CurrencyPrice { get; set; }
        public byte OrderTypeId { get; set; }

        public string OrderTypeName
        {
            get
            {
                Enum.Order.OrderType orderType = (Enum.Order.OrderType)OrderTypeId;
                switch (orderType)
                {
                    case Enum.Order.OrderType.Buy:
                        return "خرید";
                    case Enum.Order.OrderType.Sales:
                        return "فروش";
                    default:
                        return "";
                }
            }
        }
        [JsonIgnore]
        [DefaultValue(Models.Enum.Order.Status.AwaitingConfirmation)]
        public byte Status { get; set; }
        public string Description { get; set; }
        public string WaletCode { get; set; }

    }
}
