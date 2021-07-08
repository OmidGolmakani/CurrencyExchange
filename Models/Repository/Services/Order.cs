using CurrencyExchange.Data;
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

        public Order(Repository<Entity.Order, long> repository)
        {
            this.orderRepository = repository;
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

        public Task<IEnumerable<Entity.Order>> GetAll()
        {
            return orderRepository.GetAll();
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

        public void UpdateRange(IEnumerable<Entity.Order> entities)
        {
            orderRepository.UpdateRange(entities);
        }
    }
}
