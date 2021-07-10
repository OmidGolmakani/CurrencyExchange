using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.Currencies;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class CurrencyController : BaseController<CurrencyController>, IController<CUCurrencyDto, int>
    {
        private readonly ICurrency _CurrencySrv;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public CurrencyController(ICurrency CurrencySrv,
                                  IMapper mapper,
                                  ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this._CurrencySrv = CurrencySrv;
            this.mapper = mapper;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUCurrencyDto entity)
        {
            var _entity = mapper.Map<CUCurrencyDto, Currency>(entity);
            CurrencyValidator validator = new CurrencyValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            var Result = _CurrencySrv.Add(_entity);
            _CurrencySrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var _entity = await _CurrencySrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _CurrencySrv.Remove(Id);
            _CurrencySrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUCurrencyDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            Currency _entity = new Currency();
            mapper.Map<CUCurrencyDto, Currency>(entity, _entity);
            CurrencyValidator validator = new CurrencyValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _CurrencySrv.Update(_entity);
            _CurrencySrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<CurrencyDto>>(await _CurrencySrv.GetAll());
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
        public async Task<IActionResult> GetById(int Id)
        {
            var Result = mapper.Map<CurrencyDto>(await _CurrencySrv.GetById(Id));
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
