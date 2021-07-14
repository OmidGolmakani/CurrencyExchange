using CurrencyExchange.Controllers;
using CurrencyExchange.Models.Dto.Images;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership.Interfaces
{
    public interface IImageController : IController<CUImageDto, long>
    {
        public Task<IActionResult> GetByUserId(long UserId);
        public Task<IActionResult> AddImageWithUpload(IFormFile file,[FromForm] CUImageDto entity);
    }
}
