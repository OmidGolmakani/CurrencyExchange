using CurrencyExchange.Models.Dto.AuthUserItems;
using Microsoft.AspNetCore.Http;
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
        public Task<IActionResult> AddAll(IFormFile UserImgFile,
                                            IFormFile NationalCodeImgFile,
                                            IFormFile BankCardImgFile,
                                            [FromForm] CAuthUserItemsDto entity);
        public Task<ActionResult> UpdateAuthUserStatus(long UserId, long AdminId, byte Status);
    }
}
