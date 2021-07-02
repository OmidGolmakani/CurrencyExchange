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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IMapper Mapper;
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context, IMapper Mapper)
        {
            this.Mapper = Mapper;
            _context = context;
        }

        public Task<TEntity> GetById(object Id)
        {
            return _context.Set<TEntity>().FindAsync(Id).AsTask();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return Task.FromResult(_context.Set<TEntity>().AsEnumerable());
        }

        public Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return Task.FromResult(_context.Set<TEntity>().Where(expression).AsEnumerable());
        }

        public Task<EntityEntry<TEntity>> Add(TEntity entity)
        {
            var Result = _context.Set<TEntity>().AddAsync(entity).AsTask();
            return Result;
        }

        public Task AddRange(IEnumerable<TEntity> entities)
        {
            return _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
