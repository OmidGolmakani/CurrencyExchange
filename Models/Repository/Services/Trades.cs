﻿using CurrencyExchange.Data;
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
    public class Trades : ITrades<long>
    {
        private readonly Repository<Entity.Trades, long> TradesRepository;

        public Trades(Repository<Entity.Trades, long> repository)
        {
            this.TradesRepository = repository;
        }

        public Task<EntityEntry<Entity.Trades>> Add(Entity.Trades entity)
        {
            return TradesRepository.Add(entity);
        }

        public Task AddRange(IEnumerable<Entity.Trades> entities)
        {
            return TradesRepository.AddRange(entities);
        }

        public Task<IEnumerable<Entity.Trades>> Find(Func<Entity.Trades, bool> expression)
        {
            return TradesRepository.Find(expression);
        }

        public Task<IEnumerable<Entity.Trades>> GetAll()
        {
            return TradesRepository.GetAll();
        }

        public Task<Entity.Trades> GetById(long Id)
        {
            return TradesRepository.GetById(Id);
        }

        public Task<long> GetNeTradeNum()
        {
            var Result = GetAll().Result;
            return Task.FromResult(Result.Count() == 0 ? 1 : Result.Max(x => x.TradeNum) + 1);
        }

        public void Remove(long Id)
        {
            TradesRepository.Remove(Id);
        }

        public void RemoveRange(IEnumerable<Entity.Trades> entities)
        {
            TradesRepository.RemoveRange(entities);
        }

        public int SaveChanges()
        {
            return TradesRepository.SaveChanges();
        }

        public void Update(Entity.Trades entity)
        {
            TradesRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Entity.Trades> entities)
        {
            TradesRepository.UpdateRange(entities);
        }
    }
}
