using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Trades
{
    public class CUTradeDto
    {
        public long Id { get; set; }
        public Nullable<long> TradeId { get; set; }

        [JsonIgnore]
        public DateTime TradeDate
        {
            get
            {
                return (Helper.PersionDate.GetMiladi(_TradeSolarDate, _TradeTime) ?? DateTime.Now);
            }
        }
        private string _TradeSolarDate = Helper.PersionDate.GetShamsiToday();
        public string TradeSolarDate
        {
            get
            {
                return _TradeSolarDate;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false && Helper.PersionDate.IsShamsi(_TradeSolarDate))
                {
                    _TradeSolarDate = value;
                }
            }
        }
        private string _TradeTime = DateTime.Now.ToString("HH:mm:ss");
        public string TradeTime
        {
            get
            {
                return _TradeTime;
            }
            set
            {
                DateTime t;
                if (string.IsNullOrEmpty(value) == false && DateTime.TryParse(_TradeTime, out t))
                {
                    _TradeSolarDate = value;
                }
            }
        }
        [JsonIgnore]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int Quantity { get; set; }
        public decimal InstantPrice { get; set; }
        public decimal CurrencyPrice { get; set; }
        public byte Status { get; set; }
        public string Description { get; set; }
    }
}
