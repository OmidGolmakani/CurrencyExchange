using CurrencyExchange.Models.Dto.AuthUserItems;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership.Interfaces
{
    public interface IAuthUserItemController : IController<CUAuthUserItemDto, long>
    {
        public Task<IActionResult> GetAuthItemsByUser(long UserId);
    }
}
