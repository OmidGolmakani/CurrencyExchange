using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Interfaces
{
    public interface IRepository<TEntiy,T> where TEntiy : class
    {
        Task<TEntiy> GetById(T Id);
        Task<IEnumerable<TEntiy>> GetAll();
        Task<IEnumerable<TEntiy>> Find(Func<TEntiy, bool> expression);
        Task<EntityEntry<TEntiy>> Add(TEntiy entity);
        Task AddRange(IEnumerable<TEntiy> entities);
        void Update(TEntiy entity);
        void UpdateRange(IEnumerable<TEntiy> entities);
        void Remove(T Id);
        void RemoveRange(IEnumerable<TEntiy> entities);
        int SaveChanges();
    }
}
