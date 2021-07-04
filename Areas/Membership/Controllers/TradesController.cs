using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helper;
using CurrencyExchange.Models.Dto.Trades;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class TradesController : BaseController<TradesController>, IController<CUTradeDto, long>
    {
        private readonly Models.Repository.Services.Trades _TradesSrv;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public TradesController(Models.Repository.Services.Trades TradesSrv,
                                  IMapper mapper,
                                  ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this._TradesSrv = TradesSrv;
            this.mapper = mapper;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUTradeDto entity)
        {
            var _entity = mapper.Map<CUTradeDto, Trades>(entity);
            _entity.Status = (byte)Models.Enum.Trades.Status.AwaitingConfirmation;
            TradesValidator validator = new TradesValidator(dbContext);
            _entity.TradeNum = await _TradesSrv.GetNeTradeNum();
            validator.ValidateAndThrow(_entity);
            var Result = _TradesSrv.Add(_entity);
            _TradesSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _TradesSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _TradesSrv.Remove(Id);
            _TradesSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUTradeDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            Trades _entity = new Trades();
            mapper.Map<CUTradeDto, Trades>(entity, _entity);
            TradesValidator validator = new TradesValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _TradesSrv.Update(_entity);
            _TradesSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<TradesDto>>(await _TradesSrv.GetAll());
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
            var Result = await _TradesSrv.GetById(Id);
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
