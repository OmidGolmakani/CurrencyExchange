using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.CurrencyChanges
{
    public class CUCurrencyChangeDto
    {
        public Nullable<int> Id { get; set; }
        public int CurrencyId { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }
        [JsonIgnore]
        public DateTime LastChangeDate
        {
            get
            {
                return (Helper.PersionDate.GetMiladi(_LastChangeSolarDate, _LastChangeSolarDate) ?? DateTime.Now);
            }
        }
        private string _LastChangeSolarDate = Helper.PersionDate.GetShamsiToday();
        public string LastChangeSolarDate
        {
            get
            {
                return _LastChangeSolarDate;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false && Helper.PersionDate.IsShamsi(_LastChangeSolarDate))
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
