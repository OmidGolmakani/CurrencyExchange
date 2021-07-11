using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Models.Repository.Services;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class CurrencyChangeController : BaseController<CurrencyChangeController>, IController<CUCurrencyChangeDto, long>
    {
        private readonly IRepository<CurrencyChange, long> _currencyChangeSrv;
        private readonly ICurrency _currencySrv;
        private readonly IMapper mapper;
        private readonly CurrencyExchangeHub _currencyExchangeHubSvr;
        private readonly ApplicationDbContext dbContext;

        public CurrencyChangeController(IRepository<CurrencyChange, long> currencyChangeSrv,
                                        ICurrency currencySrv,
                                        IMapper mapper,
                                        CurrencyExchangeHub currencyExchangeHubSvr,
                                        ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this._currencyChangeSrv = currencyChangeSrv;
            this._currencySrv = currencySrv;
            this.mapper = mapper;
            this._currencyExchangeHubSvr = currencyExchangeHubSvr;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUCurrencyChangeDto entity)
        {
            var _entity = mapper.Map<CUCurrencyChangeDto, CurrencyChange>(entity);
            CurrencyChangeValidator validator = new CurrencyChangeValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            var Result = _currencyChangeSrv.Add(_entity);
            _currencySrv.UpdateCurrencyPrices(_entity.CurrencyId,
                                              _entity.PurchasePrice,
                                              _entity.SalesPrice);
            _currencyChangeSrv.SaveChanges();
            
            await _currencyExchangeHubSvr.CurrencyChange(mapper.Map<Models.Dto.CurrencyExchangeHub.CurrencyChangeDto>(_entity));
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _currencyChangeSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _currencyChangeSrv.Remove(Id);
            _currencyChangeSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUCurrencyChangeDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            CurrencyChange _entity = new CurrencyChange();
            mapper.Map<CUCurrencyChangeDto, CurrencyChange>(entity, _entity);
            CurrencyChangeValidator validator = new CurrencyChangeValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _currencyChangeSrv.Update(_entity);
            _currencyChangeSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<CurrencyChangeDto>>(await _currencyChangeSrv.GetAll());
            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpPost("GetDetail{Id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            var Result = mapper.Map<CurrencyChangeDto>(await _currencyChangeSrv.GetById(Id));
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
