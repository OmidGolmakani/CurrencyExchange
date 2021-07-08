using CurrencyExchange.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Trades
{
    public class TradeDto : Base.BaseDto
    {
        public Nullable<long> Id { get; set; }
        public long OrderId { get; set; }
        public string UserFullName { get; set; }
        [JsonIgnore]
        public DateTime TradeDate { get; set; }
        public string TradeSolarDate
        {
            get
            {
                return TradeDate.ToShamsi(false);
            }
        }
        public string TradeTime
        {
            get
            {
                return TradeDate.ToString("HH:mm:ss");
            }
        }
        [JsonIgnore]
        public int CurrencyId { get; set; }
        public int Quantity { get; set; }
        public decimal CurrencyPrice { get; set; }
        public string Description { get; set; }
    }
}
