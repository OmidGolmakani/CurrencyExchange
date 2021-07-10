using CurrencyExchange.CustomException;
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
    public class Currency : ICurrency
    {
        private readonly Repository<Entity.Currency, int> currencyRepository;
        private readonly ApplicationDbContext dbContext;

        public Currency(Repository<Entity.Currency, int> currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public Task<EntityEntry<Entity.Currency>> Add(Entity.Currency entity)
        {
            return currencyRepository.Add(entity);
        }

        public Task AddRange(IEnumerable<Entity.Currency> entities)
        {
            return currencyRepository.AddRange(entities);
        }

        public Task<IEnumerable<Entity.Currency>> Find(Expression<Func<Entity.Currency, bool>> expression)
        {
            return currencyRepository.Find(expression);
        }

        public Task<IEnumerable<Entity.Currency>> GetAll()
        {
            return currencyRepository.GetAll();
        }

        public Task<Entity.Currency> GetById(int Id)
        {
            return currencyRepository.GetById(Id);
        }

        public void Remove(int Id)
        {
            currencyRepository.Remove(Id);
        }

        public void RemoveRange(IEnumerable<Entity.Currency> entities)
        {
            currencyRepository.RemoveRange(entities);
        }

        public int SaveChanges()
        {
            return currencyRepository.SaveChanges();
        }

        public void Update(Entity.Currency entity)
        {
            currencyRepository.Update(entity);
        }

        public void UpdateCurrencyPrices(int CurrencyId,
                                         Nullable<decimal> PurchasePrice,
                                         Nullable<decimal> SalesPrice)
        {
            var currency = GetById(CurrencyId).Result;
            if (currency == null)
            {
                throw new MyException("ارز مورد نظر یافت نشد");
            }
            currency.PurchasePrice = PurchasePrice;
            currency.SalesPrice = SalesPrice;
        }

        public void UpdateRange(IEnumerable<Entity.Currency> entities)
        {
            currencyRepository.UpdateRange(entities);
        }
    }
}
