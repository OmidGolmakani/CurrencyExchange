using AutoMapper;
using CurrencyExchange.Data;
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
    public abstract class Repository<T> : IRepository<T> where T : class, new()
    {
        protected IMapper Mapper;
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context, IMapper Mapper)
        {
            this.Mapper = Mapper;
            _context = context;
        }

        public ValueTask<T> GetById(object Id)
        {
            return _context.Set<T>().FindAsync(Id);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return Task.FromResult(_context.Set<T>().AsEnumerable());
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return Task.FromResult(_context.Set<T>().Where(expression).AsEnumerable());
        }

        public ValueTask<EntityEntry<T>> Add(T entity)
        {
            return _context.Set<T>().AddAsync(entity);
        }

        public Task AddRange(IEnumerable<T> entities)
        {
            return _context.Set<T>().AddRangeAsync(entities);
        }

        public EntityEntry<T> Update(T entity)
        {
            return _context.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
