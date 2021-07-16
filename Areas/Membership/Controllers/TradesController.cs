using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.Trades;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class TradesController : BaseController<TradesController>, ITradeController
    {
        private readonly Models.Repository.Services.Trades _tradesSrv;
        private readonly Models.Repository.Services.Order _orderSrv;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public TradesController(Models.Repository.Services.Trades tradesSrv,
                                Models.Repository.Services.Order orderSrv,
                                IMapper mapper,
                                ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this._tradesSrv = tradesSrv;
            _orderSrv = orderSrv;
            this.mapper = mapper;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUTradeDto entity)
        {
            var _entity = mapper.Map<CUTradeDto, Trades>(entity);
            TradesValidator validator = new TradesValidator(dbContext);
            _entity.TradeNum = await _tradesSrv.GetNewTradeNum();
            validator.ValidateAndThrow(_entity);
            var Result = _tradesSrv.Add(_entity);
            await _orderSrv.UpdateAdminOrder(entity.OrderId, entity.Description);
            _tradesSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _tradesSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _tradesSrv.Remove(Id);
            _tradesSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpGet("Find")]
        public async Task<IActionResult> Find(string dateFrom, string dateTo)
        {
            DateTime _dateFrom = dateFrom.ToMiladi();
            DateTime _dateTo = dateTo.ToMiladi();

            var Result = mapper.Map<List<TradeDto>>(await _tradesSrv.Find(x => x.TradeDate.Date >= _dateFrom
                                                                            && x.TradeDate.Date <= _dateTo));
            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUTradeDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            Trades _entity = new Trades();
            mapper.Map<CUTradeDto, Trades>(entity, _entity);
            TradesValidator validator = new TradesValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _tradesSrv.Update(_entity);
            await _orderSrv.UpdateAdminOrder(entity.OrderId, entity.Description);
            _tradesSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<TradeDto>>(await _tradesSrv.GetAll());
            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpGet("GetDetail{Id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            var Result = mapper.Map<TradeDto>(await _tradesSrv.GetById(Id));
            if (Result == null)
            {
                return NotFound(DefaultMessages.NotFound);
            }
            else
            {
                return Ok(Result);
            }
        }

        public async Task<IActionResult> GetTradeByUserId(long UserId)
        {
            var Result = mapper.Map<TradeDto>(await _tradesSrv.GetTradesByUserId(UserId));
            if (Result == null)
            {
                return NotFound(DefaultMessages.NotFound);
            }
            else
            {
                return Ok(Result);
            }
        }
    }
}
