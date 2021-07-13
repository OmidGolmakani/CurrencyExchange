using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.AuthUserItems;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class AuthUserItemController : BaseController<AuthUserItemController>, IController<CUAuthUserItemDto,long>
    {
        private readonly IMapper mapper;
        private readonly IRepository<AuthUserItem, long> _authUserItemSrv;
        private readonly ApplicationDbContext dbContext;

        public AuthUserItemController(IMapper mapper,
                                      IRepository<AuthUserItem,long> authUserItemSrv,
                                      ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this.mapper = mapper;
            this._authUserItemSrv = authUserItemSrv;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUAuthUserItemDto entity)
        {
            var _entity = mapper.Map<CUAuthUserItemDto, AuthUserItem>(entity);
            AuthUserItemValidator validator = new AuthUserItemValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            var Result = _authUserItemSrv.Add(_entity);
            _authUserItemSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _authUserItemSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _authUserItemSrv.Remove(Id);
            _authUserItemSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUAuthUserItemDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            AuthUserItem _entity = new AuthUserItem();
            mapper.Map<CUAuthUserItemDto, AuthUserItem>(entity, _entity);
            AuthUserItemValidator validator = new AuthUserItemValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _authUserItemSrv.Update(_entity);
            _authUserItemSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<AuthUserItem>>(await _authUserItemSrv.GetAll());
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
            var Result = mapper.Map<AuthUserItemDto>(await _authUserItemSrv.GetById(Id));
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
