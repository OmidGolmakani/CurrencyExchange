using CurrencyExchange.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Interfaces
{
    public interface IImage : IRepository<Image,long>
    {
        Task<IEnumerable<Image>> GetImageByUserId(long UserId);
    }
}
