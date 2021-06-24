using CurrencyExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.IRepository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext DbContext { get; set; }
        public RepositoryBase(ApplicationDbContext dbContext)
        {
            this.DbContext = DbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.DbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.DbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.DbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
        }
    }
