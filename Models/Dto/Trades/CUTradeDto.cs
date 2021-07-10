using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Trades
{
    public class CUTradeDto : Base.BaseDto
    {
        public Nullable<long> Id { get; set; }
        public long OrderId { get; set; }
        private string _TradeSolarDate = Helpers.PersionDate.GetShamsiToday();

        public string TradeSolarDate 
            {
            get
            {
                return _TradeSolarDate;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false && Helpers.PersionDate.IsShamsi(_TradeSolarDate))
                {
                    _TradeSolarDate = value;
                }
            }
        }

        private DateTime _TradeDate;
        [JsonIgnore]
        public DateTime TradeDate
        {
            get
            {
                return (Helpers.PersionDate.GetMiladi(TradeSolarDate, TradeTime) ?? DateTime.Now);
            }
            set
            {
                _TradeDate = value;
            }
        }
        private string _OrderTime = DateTime.Now.ToString("HH:mm:ss");
        public string TradeTime
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
                    _TradeSolarDate = value;
                }
            }
        }
        public int Quantity { get; set; }
        public decimal CurrencyPrice { get; set; }
        public string Description { get; set; }
    }
}
