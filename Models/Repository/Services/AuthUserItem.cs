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
    public class AuthUserItem : IAuthUserItem
    {
        private readonly Repository<Entity.AuthUserItem, long> _authUserItemRepository;

        public AuthUserItem(Repository<Entity.AuthUserItem, long> authUserItemRepository)
        {
            this._authUserItemRepository = authUserItemRepository;
        }

        public Task<EntityEntry<Entity.AuthUserItem>> Add(Entity.AuthUserItem entity)
        {
            return this._authUserItemRepository.Add(entity);
        }

        public Task AddRange(IEnumerable<Entity.AuthUserItem> entities)
        {
            return this._authUserItemRepository.AddRange(entities);
        }

        public Task<IEnumerable<Entity.AuthUserItem>> Find(Expression<Func<Entity.AuthUserItem, bool>> expression)
        {
            return this._authUserItemRepository.Find(expression);
        }

        public Task<IEnumerable<Entity.AuthUserItem>> GetAll()
        {
            return this._authUserItemRepository.GetAll();
        }

        public Task<IEnumerable<Entity.AuthUserItem>> GetAuthItemsByUser(long UserId)
        {
            return Task.FromResult(this._authUserItemRepository.GetAll().Result.Where(x => x.UserId == UserId).AsEnumerable());
        }

        public Task<Entity.AuthUserItem> GetById(long Id)
        {
            return this._authUserItemRepository.GetById(Id);
        }

        public void Remove(long Id)
        {
            this._authUserItemRepository.Remove(Id);
        }

        public void RemoveRange(IEnumerable<Entity.AuthUserItem> entities)
        {
            this._authUserItemRepository.RemoveRange(entities);
        }

        public int SaveChanges()
        {
            return this._authUserItemRepository.SaveChanges();
        }

        public void Update(Entity.AuthUserItem entity)
        {
            this._authUserItemRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Entity.AuthUserItem> entities)
        {
            this._authUserItemRepository.UpdateRange(entities);
        }
    }
}
