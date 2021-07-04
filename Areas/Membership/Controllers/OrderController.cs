using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helper;
using CurrencyExchange.Models.Dto.Orders;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class OrderController : BaseController<OrderController>, IController<OrderDto>
    {
        private readonly Models.Repository.Services.Order _OrderSrv;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public OrderController(Models.Repository.Services.Order OrderSrv,
                                  IMapper mapper,
                                  ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this._OrderSrv = OrderSrv;
            this.mapper = mapper;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUOrderDto entity)
        {
            var _entity = mapper.Map<CUOrderDto, Order>(entity);
            _entity.Status = (byte)Models.Enum.Order.Status.AwaitingConfirmation;
            OrderValidator validator = new OrderValidator(dbContext);
            _entity.OrderNum = await _OrderSrv.GetNeOrderNum();
            validator.ValidateAndThrow(_entity);
            var Result = _OrderSrv.Add(_entity);
            _OrderSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(object Id)
        {
            var _entity = await _OrderSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _OrderSrv.Remove(_entity);
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUOrderDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            Order _entity = new Order();
            mapper.Map<CUOrderDto, Order>(entity, _entity);
            OrderValidator validator = new OrderValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _OrderSrv.Update(_entity);
            _OrderSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<OrderDto>>(await _OrderSrv.GetAll());
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
        public async Task<IActionResult> GetById(object Id)
        {
            var Result = await _OrderSrv.GetById(Id);
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
