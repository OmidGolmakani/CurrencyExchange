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
        private readonly Repository<Entity.Order> orderRepository;

        public Order(Repository<Entity.Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Task<EntityEntry<Entity.Order>> Add(Entity.Order entity)
        {
            return orderRepository.Add(entity);
        }

        public Task AddRange(IEnumerable<Entity.Order> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Order>> Find(Expression<Func<Entity.Order, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Entity.Order> GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetNeOrderNum()
        {
            throw new NotImplementedException();
        }

        public void Remove(Entity.Order entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Entity.Order> entities)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Entity.Order entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Entity.Order> entities)
        {
            throw new NotImplementedException();
        }
    }
}
