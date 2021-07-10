using CurrencyExchange.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Interfaces
{
    public interface ICurrency : IRepository<Currency, int>
    {
        public void UpdateCurrencyPrices(int CurrencyId, 
                                         Nullable<decimal> PurchasePrice,
                                         Nullable<decimal> SalesPrice);
    }
}
