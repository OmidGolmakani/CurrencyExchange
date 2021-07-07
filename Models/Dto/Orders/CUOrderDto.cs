using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CurrencyExchange.Models.Dto.Orders
{
    public class CUOrderDto
    {
        public Nullable<long> Id { get; set; }
        [JsonIgnore]
        public DateTime OrderDate
        {
            get
            {
                return (Helper.PersionDate.GetMiladi(_OrderSolarDate, _OrderTime) ?? DateTime.Now);
            }
        }

        private string _OrderSolarDate = Helper.PersionDate.GetShamsiToday();
        public string OrderSolarDate
        {
            get
            {
                return _OrderSolarDate;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false && Helper.PersionDate.IsShamsi(_OrderSolarDate))
                {
                    _OrderSolarDate = value;
                }
            }
        }
        private string _OrderTime = DateTime.Now.ToString("HH:mm:ss");
        public string OrderTime
        {
            get
            {
                return _OrderTime;
            }
            set
            {
                DateTime t;
                if (string.IsNullOrEmpty(value) == false && DateTime.TryParse(_OrderTime, out t))
                {
                    _OrderSolarDate = value;
                }
            }
        }
        [JsonIgnore]
        public long OrderNum { get; set; }
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
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int Quantity { get; set; }
        public decimal InstantPrice { get; set; }
        public decimal CurrencyPrice { get; set; }
        [JsonIgnore]
        [DefaultValue(Models.Enum.Order.Status.AwaitingConfirmation)]
        public byte Status { get; set; }
        public string Description { get; set; }
    }
}
