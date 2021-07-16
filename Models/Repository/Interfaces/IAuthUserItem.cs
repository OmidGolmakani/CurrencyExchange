using CurrencyExchange.Models.Dto.AuthUserItems;
using CurrencyExchange.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Interfaces
{
    public interface IAuthUserItem : IRepository<AuthUserItem, long>
    {
        public Task<IEnumerable<AuthUserItem>> GetAuthItemsByUser(long UserId);
        public Task<bool> IsCompleteAuthUsers(long UserId);
        public Task<AuthUserStatusDto> GetAuthUserStatus(long UserId);
    }
}
