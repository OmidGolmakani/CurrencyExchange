using CurrencyExchange.CustomException;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.Orders;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Services
{
    public class Order : IOrder
    {
        private readonly Repository<Entity.Order, long> orderRepository;
        private readonly ApplicationDbContext dbContext;

        public Order(Repository<Entity.Order, long> repository,
                     ApplicationDbContext dbContext)
        {
            this.orderRepository = repository;
            this.dbContext = dbContext;
        }

        public Task<EntityEntry<Entity.Order>> Add(Entity.Order entity)
        {
            return orderRepository.Add(entity);
        }

        public Task AddRange(IEnumerable<Entity.Order> entities)
        {
            return orderRepository.AddRange(entities);
        }

        public Task<IEnumerable<Entity.Order>> Find(Expression<Func<Entity.Order, bool>> expression)
        {
            return orderRepository.Find(expression);
        }

        public Task<Entity.Order> FirstOrDefault(IEnumerable<Entity.Order> source)
        {
            return orderRepository.FirstOrDefault(source);
        }

        public Task<Entity.Order> FirstOrDefault(IEnumerable<Entity.Order> source, Func<Entity.Order, bool> predicate)
        {
            return orderRepository.FirstOrDefault(source, predicate);
        }

        public Task<IEnumerable<Entity.Order>> GetAll()
        {
            return Task.FromResult(orderRepository.GetAll().Result);
        }

        public Task<Entity.Order> GetById(long Id)
        {
            return orderRepository.GetById(Id);
        }

        public Task<long> GetNewOrderNum()
        {
            var Result = GetAll().Result;
            return Task.FromResult(Result.Count() == 0 ? 1 : Result.Max(x => x.OrderNum) + 1);
        }

        public Task<IEnumerable<Models.Entity.Order>> GetOrderByStatus(Enum.Order.Status status)
        {
            var Result = orderRepository.GetAll().Result.Where(x => x.Status == (byte)status);
            return Task.FromResult(Result);
        }

        public Task<IEnumerable<Entity.Order>> GetOrderByUserId(long UserId, Models.Enum.Order.OrderType type, string dateFrom, string dateTo)
        {
            DateTime _dateFrom = DateTime.Now;
            DateTime _dateTo = DateTime.Now;

            if (dateFrom.DateIsValid() && dateTo.DateIsValid())
            {
                _dateFrom = dateFrom.ToMiladi();
                _dateTo = dateTo.ToMiladi();
                if (type == Enum.Order.OrderType.None)
                {
                    return orderRepository.Find(x => x.Status != (byte)Enum.Order.Status.Confirmation && x.UserId == UserId && x.OrderDate.Date >= _dateFrom && x.OrderDate.Date <= _dateTo);
                }
                else
                {
                    return orderRepository.Find(x => x.Status != (byte)Enum.Order.Status.Confirmation && x.UserId == UserId && x.OrderDate.Date >= _dateFrom && x.OrderDate.Date <= _dateTo && x.OrderTypeId == (byte)type);
                }
            }
            else
            {
                if (type == Enum.Order.OrderType.None)
                {
                    return orderRepository.Find(x => x.Status != (byte)Enum.Order.Status.Confirmation && x.UserId == UserId);
                }
                else
                {
                    return orderRepository.Find(x => x.Status != (byte)Enum.Order.Status.Confirmation && x.UserId == UserId && x.OrderTypeId == (byte)type);
                }
            }
        }

        public void Remove(long Id)
        {
            orderRepository.Remove(Id);
        }

        public void RemoveRange(IEnumerable<Entity.Order> entities)
        {
            orderRepository.RemoveRange(entities);
        }

        public int SaveChanges()
        {
            return orderRepository.SaveChanges();
        }

        public void Update(Entity.Order entity)
        {
            orderRepository.Update(entity);
        }

        public Task UpdateAdminOrder(long OrderId, string AdminDesctiption)
        {
            var Order = GetById(OrderId).Result;
            if (Order == null)
            {
                throw new MyException("درخواست مورد نظر یافت نشد");
            }
            var AdminInfo = Helpers.Helper.GetAdminInfo();
            Order.AdminConfirmDate = AdminInfo.AdminConfirmDate;
            Order.AdminDescription = AdminDesctiption;
            Order.AdminId = AdminInfo.AdminId;
            Order.VerifyType = AdminInfo.VerifyType;
            return Task.Run(() => true);
        }

        public void UpdateOrderStatus(long OrderId, Enum.Order.Status status)
        {
            var Result = orderRepository.GetById(OrderId).Result;
            if (Result != null)
            {
                Result.Status = (byte)status;
                orderRepository.Update(Result);
            }
            else
            {
                throw new MyException(DefaultMessages.UserNotFound);
            }
        }

        public void UpdateRange(IEnumerable<Entity.Order> entities)
        {
            orderRepository.UpdateRange(entities);
        }
    }
}
