using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.CustomException;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class CurrencyChangeController : BaseController<CurrencyChangeController>, IController<CurrencyChangeDto>
    {
        private readonly Repository<CurrencyChangeDto> _currencyChangeSrv;
        public CurrencyChangeController(Repository<CurrencyChangeDto> currencyChangeSrv)
        {
            _currencyChangeSrv = currencyChangeSrv;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CurrencyChangeDto data)
        {
            //_currencyChangeSrv.Add(data, typeof(CurrencyChange));
            return Ok(await Task.FromResult(""));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(object Id)
        {
            return Ok(await Task.FromResult(""));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CurrencyChangeDto data)
        {
            return Ok(await Task.FromResult(""));
        }
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Task.FromResult(""));
        }
        [HttpPost("GetDetail{Id}")]
        public async Task<IActionResult> GetById(object Id)
        {
            return Ok(await Task.FromResult(""));
        }
    }
}
