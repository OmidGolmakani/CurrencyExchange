﻿using System;
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
        public Nullable<long> OrderId { get; set; }
        public string TradeSolarDate { get; set; }

        private DateTime _TradeDate;
        [JsonIgnore]
        public DateTime TradeDate
        {
            get
            {
                return (Helper.PersionDate.GetMiladi(TradeSolarDate, TradeTime) ?? DateTime.Now);
            }
            set
            {
                _TradeDate = value;
            }
        }
        public string TradeTime { get; set; }
        [JsonIgnore]
        public long UserId { get; set; }
        public int CurrencyId { get; set; }
        public int Quantity { get; set; }
        public decimal InstantPrice { get; set; }
        public decimal CurrencyPrice { get; set; }
        public byte Status { get; set; }
        public string Description { get; set; }
    }
}
