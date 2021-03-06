using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.CustomException;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.Orders;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class OrderController : BaseController<OrderController>, IOrderController
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
            entity.InstantPrice = 1000;
            var _entity = mapper.Map<CUOrderDto, Order>(entity);
            _entity.Status = (byte)Models.Enum.Order.Status.AwaitingConfirmation;
            OrderValidator validator = new OrderValidator(dbContext);
            _entity.OrderNum = await _OrderSrv.GetNewOrderNum();
            validator.ValidateAndThrow(_entity);
            _entity.Status = (byte)Models.Enum.Order.Status.AwaitingConfirmation;
            var Result = _OrderSrv.Add(_entity);
            _OrderSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _OrderSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _OrderSrv.Remove(Id);
            _OrderSrv.SaveChanges();
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
            _entity.Status = (byte)Models.Enum.Order.Status.AwaitingConfirmation;
            _OrderSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("Find")]
        public async Task<IActionResult> Find(string dateFrom, string dateTo, Models.Enum.Order.OrderType type)
        {
            DateTime _dateFrom = DateTime.Now;
            DateTime _dateTo = DateTime.Now;
            if (dateFrom.DateIsValid() && dateTo.DateIsValid())
            {
                _dateFrom = dateFrom.ToMiladi();
                _dateTo = dateTo.ToMiladi();
            }

            List<OrderDto> Result = null;
            if (dateFrom.DateIsValid() && dateTo.DateIsValid() && type != Models.Enum.Order.OrderType.None)
            {
                Result = mapper.Map<List<OrderDto>>(await _OrderSrv.Find(x => x.Status != (byte)Models.Enum.Order.Status.Confirmation
                                                                          && x.OrderDate >= _dateFrom.Date
                                                                          && x.OrderDate.Date <= _dateTo.Date
                                                                          && x.OrderTypeId == (byte)type));
            }
            else if (dateFrom.DateIsValid() && dateTo.DateIsValid() && type == Models.Enum.Order.OrderType.None)
            {
                Result = mapper.Map<List<OrderDto>>(await _OrderSrv.Find(x => x.Status != (byte)Models.Enum.Order.Status.Confirmation &&
                                                                              x.OrderDate >= _dateFrom.Date &&
                                                                              x.OrderDate.Date <= _dateTo.Date));
            }
            else if ((dateFrom.DateIsValid() == false || dateTo.DateIsValid() == false) && type != Models.Enum.Order.OrderType.None)
            {
                Result = mapper.Map<List<OrderDto>>(await _OrderSrv.Find(x => x.Status != (byte)Models.Enum.Order.Status.Confirmation &&
                                                                              x.OrderTypeId == (byte)type));
            }
            else
            {
                Result = mapper.Map<List<OrderDto>>(_OrderSrv.GetAll().Result.Where(x => x.Status != (byte)Models.Enum.Order.Status.Confirmation).ToList());
            }

            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = await _OrderSrv.GetAll();
            Result = Result.Where(x => x.Status != (byte)Models.Enum.Order.Status.Confirmation).ToList();
            if (Result.Count() == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(mapper.Map<List<OrderDto>>(Result));
            }
        }
        [HttpGet("GetDetail{Id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            var Result = mapper.Map<OrderDto>(await _OrderSrv.GetById(Id));
            if (Result == null)
            {
                return NotFound(DefaultMessages.NotFound);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpGet("GetOrderByUser{UserId}")]
        public async Task<IActionResult> GetOrderByUserId(long UserId, Models.Enum.Order.OrderType type, string dateFrom, string dateTo)
        {
            var Result = await _OrderSrv.GetOrderByUserId(UserId, type, dateFrom, dateTo);
            if (Result == null)
            {
                return NotFound(DefaultMessages.NotFound);
            }
            else
            {
                return Ok(mapper.Map<List<OrderDto>>(Result));
            }
        }

        [HttpGet("GetOrdersByStatus")]
        public async Task<IActionResult> GetOrdersByStatus(byte status)
        {
            Models.Enum.Order.Status status1 = (Models.Enum.Order.Status)status;
            var Result = mapper.Map<List<OrderDto>>(await _OrderSrv.GetOrderByStatus(status1));
            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpPost("UpdateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus(long OrderId, byte status)
        {
            Models.Enum.Order.Status status1 = (Models.Enum.Order.Status)status;
            if (status1 == Models.Enum.Order.Status.Confirmation)
            {
                await Task.FromResult(false);
            }
            _OrderSrv.UpdateOrderStatus(OrderId, status1);
            _OrderSrv.SaveChanges();
            return Ok(await Task.FromResult(true));
        }
    }
}
