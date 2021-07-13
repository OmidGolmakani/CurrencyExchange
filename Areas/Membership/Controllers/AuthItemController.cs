using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.AuthItems;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class AuthItemController : BaseController<AuthItemController>, IController<CUAuthItemDto,long>
    {
        private readonly IMapper mapper;
        private readonly IRepository<AuthItem, long> _AuthItemSrv;
        private readonly ApplicationDbContext dbContext;

        public AuthItemController(IMapper mapper,
                                      IRepository<AuthItem,long> AuthItemSrv,
                                      ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this.mapper = mapper;
            this._AuthItemSrv = AuthItemSrv;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUAuthItemDto entity)
        {
            var _entity = mapper.Map<CUAuthItemDto, AuthItem>(entity);
            AuthItemValidator validator = new AuthItemValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            var Result = _AuthItemSrv.Add(_entity);
            _AuthItemSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _AuthItemSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _AuthItemSrv.Remove(Id);
            _AuthItemSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUAuthItemDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            AuthItem _entity = new AuthItem();
            mapper.Map<CUAuthItemDto, AuthItem>(entity, _entity);
            AuthItemValidator validator = new AuthItemValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _AuthItemSrv.Update(_entity);
            _AuthItemSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<AuthItem>>(await _AuthItemSrv.GetAll());
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
            var Result = mapper.Map<AuthItemDto>(await _AuthItemSrv.GetById(Id));
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
