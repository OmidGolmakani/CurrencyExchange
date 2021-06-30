using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.CurrencyChanges
{
    public class CurrencyChangeDto
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime LastChangeDate { get; set; }
        public string LastChangeSolarDate
        {
            get
            {
                return Helper.PersionDate.GetShamsi(LastChangeDate);
            }
        }
        public string LastChangeTime
        {
            get
            {
                return Helper.PersionDate.GetTimeFromDate(LastChangeDate);
            }
        }
    }
}
