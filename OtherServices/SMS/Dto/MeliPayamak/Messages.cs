using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.SMS.Dto.MeliPayamak
{
    public class Messages
    {
        public long MsgID { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public byte FirstLocation { get; set; }
        public byte CurrentLocation { get; set; }
        public byte Parts { get; set; }
        public byte RecCount { get; set; }
        public byte RecFailed { get; set; }
        public byte RecSuccess { get; set; }
        public bool IsUnicode { get; set; }
    }
}
