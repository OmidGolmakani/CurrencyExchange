using CurrencyExchange.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.CurrencyExchangeHub
{
    public class CurrencyChangeDto : EmptyBaseDto
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        [JsonIgnore]
        public DateTime LastChangeDate
        {
            get
            {
                return (Helpers.PersionDate.GetMiladi(_LastChangeSolarDate, _LastChangeTime) ?? DateTime.Now);
            }
        }
        private string _LastChangeSolarDate = Helpers.PersionDate.GetShamsiToday();
        public string LastChangeSolarDate
        {
            get
            {
                return _LastChangeSolarDate;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false && Helpers.PersionDate.IsShamsi(_LastChangeSolarDate))
                {
                    _LastChangeSolarDate = value;
                }
            }
        }
        private string _LastChangeTime = DateTime.Now.ToString("HH:mm:ss");
        public string LastChangeTime
        {
            get
            {
                return _LastChangeTime;
            }
            set
            {
                DateTime t;
                if (string.IsNullOrEmpty(value) == false && DateTime.TryParse(_LastChangeTime, out t))
                {
                    _LastChangeSolarDate = value;
                }
            }
        }
    }
}
