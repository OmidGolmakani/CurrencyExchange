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
                return (Helpers.PersionDate.GetMiladi(_OrderSolarDate, _OrderTime) ?? DateTime.Now);
            }
        }

        private string _OrderSolarDate = Helpers.PersionDate.GetShamsiToday();
        public string OrderSolarDate
        {
            get
            {
                return _OrderSolarDate;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false && Helpers.PersionDate.IsShamsi(_OrderSolarDate))
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
        public long UserId { get; set; }
        public int CurrencyId { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public Nullable<decimal> InstantPrice { get; set; }
        public decimal CurrencyPrice { get; set; }
        [JsonIgnore]
        [DefaultValue(Models.Enum.Order.Status.AwaitingConfirmation)]
        public byte Status { get; set; }
        public string Description { get; set; }
    }   
}
