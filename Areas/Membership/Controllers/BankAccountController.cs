using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helper;
using CurrencyExchange.Models.Dto.BankAccounts;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class BankAccountController : BaseController<BankAccountController>, IController<CUBankAccountDto,long>
    {
        private readonly IMapper mapper;
        private readonly IRepository<BankAccount, long> _bankAccountSrv;
        private readonly ApplicationDbContext dbContext;

        public BankAccountController(IMapper mapper,
                                     IRepository<BankAccount,long> bankAccountSrv,
                                     ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this.mapper = mapper;
            this._bankAccountSrv = bankAccountSrv;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUBankAccountDto entity)
        {
            var _entity = mapper.Map<CUBankAccountDto, BankAccount>(entity);
            BankAccountValidator validator = new BankAccountValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            var Result = _bankAccountSrv.Add(_entity);
            _bankAccountSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _bankAccountSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _bankAccountSrv.Remove(Id);
            _bankAccountSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUBankAccountDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            BankAccount _entity = new BankAccount();
            mapper.Map<CUBankAccountDto, BankAccount>(entity, _entity);
            BankAccountValidator validator = new BankAccountValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _bankAccountSrv.Update(_entity);
            _bankAccountSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<BankAccount>>(await _bankAccountSrv.GetAll());
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
            var Result = mapper.Map<BankAccountDto>(await _bankAccountSrv.GetById(Id));
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
