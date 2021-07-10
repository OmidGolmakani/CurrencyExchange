using CurrencyExchange.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.CurrencyChanges
{
    public class CurrencyChangeDto : BaseDto
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyNaame { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime LastChangeDate
        {
            get
            {
                return (Helpers.PersionDate.GetMiladi(LastChangeSolarDate, LastChangeTime) ?? DateTime.Now);
            }
        }
        public string LastChangeSolarDate { get; set; }
        public string LastChangeTime { get; set; }
    }
}
