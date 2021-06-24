using CurrencyExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.IRepository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
