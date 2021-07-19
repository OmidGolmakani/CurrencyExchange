using CurrencyExchange.Models.Dto.AuthUserItems;
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
    public class AuthUserItem : IAuthUserItem
    {
        private readonly Repository<Entity.AuthUserItem, long> _authUserItemRepository;
        private readonly Repository<AuthItem, int> _authItemRepository;

        public AuthUserItem(Repository<Entity.AuthUserItem, long> authUserItemRepository,
                            Repository<Entity.AuthItem, int> authItemRepository)
        {
            this._authUserItemRepository = authUserItemRepository;
            this._authItemRepository = authItemRepository;
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

        public Task<Entity.AuthUserItem> FirstOrDefault(IEnumerable<Entity.AuthUserItem> source)
        {
            return _authUserItemRepository.FirstOrDefault(source);
        }

        public Task<Entity.AuthUserItem> FirstOrDefault(IEnumerable<Entity.AuthUserItem> source, Func<Entity.AuthUserItem, bool> predicate)
        {
            return _authUserItemRepository.FirstOrDefault(source, predicate);
        }

        public Task<IEnumerable<Entity.AuthUserItem>> GetAll()
        {
            return this._authUserItemRepository.GetAll();
        }

        public Task<IEnumerable<Entity.AuthUserItem>> GetAuthItemsByUser(long UserId)
        {
            return Task.FromResult(this._authUserItemRepository.GetAll().Result.Where(x => x.UserId == UserId).AsEnumerable());
        }

        public Task<AuthUserStatusDto> GetAuthUserStatus(long UserId)
        {
            var authAcceptCount = GetAuthItemsByUser(UserId).Result.Count(x => x.Status == (byte)Enum.AuthUserItem.Status.Accepted);
            var authCount = _authItemRepository.GetAll().Result.Count();
            AuthUserStatusDto status = null;
            if (authAcceptCount == authCount)
            {
                status = new AuthUserStatusDto()
                {
                    UserId = UserId,
                    StatusId = (byte)Enum.AuthUserItem.Status.Accepted
                };
                return Task.FromResult(status);
            }
            else if (GetAuthItemsByUser(UserId).Result.Count() == 0 ||
                GetAuthItemsByUser(UserId).Result.Count(x => x.Status == (byte)Enum.AuthUserItem.Status.Rejected) != 0)
            {
                status = new AuthUserStatusDto()
                {
                    UserId = UserId,
                    StatusId = (byte)Enum.AuthUserItem.Status.Rejected
                };
                return Task.FromResult(status);
            }
            else if (authCount == 0 ||
                     authCount == GetAuthItemsByUser(UserId).Result.Count(x => x.Status == (byte)Enum.AuthUserItem.Status.Waiting))
            {
                status = new AuthUserStatusDto()
                {
                    UserId = UserId,
                    StatusId = (byte)Enum.AuthUserItem.Status.Waiting
                };
                return Task.FromResult(status);
            }
            else
            {
                status = new AuthUserStatusDto()
                {
                    UserId = UserId,
                    StatusId = (byte)Enum.AuthUserItem.Status.Rejected
                };
                return Task.FromResult(status);
            }
        }

        public Task<Entity.AuthUserItem> GetById(long Id)
        {
            return this._authUserItemRepository.GetById(Id);
        }

        public Task<bool> IsCompleteAuthUsers(long UserId)
        {
            var authCount = this.GetAuthItemsByUser(UserId).Result.Count();
            if (authCount == 0) return Task.FromResult(false);
            var AuthUser = this.GetAuthItemsByUser(UserId).Result.ToList();
            var Auth = this._authItemRepository.GetAll().Result.ToList();
            foreach (var a in Auth)
            {
                if (AuthUser.Count(x => x.AuthItemId == a.Id && x.Status == (byte)Enum.AuthUserItem.Status.Accepted) == 0)
                {
                    return Task.FromResult(false);
                }
            }
            return Task.FromResult(true);
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

        public Task UpdateAuthUser(long UserId, byte status, long AdminId)
        {
            var AuthUserItems = this._authUserItemRepository.GetAll().Result.Where(x => x.UserId == UserId);
            AuthUserItems.ToList().ForEach(x =>
             {
                 x.Status = status;
                 x.AdminId = AdminId;
                 x.VerifyType = 1;
                 x.AdminConfirmDate = DateTime.Now;
             });
            return Task.Run(() => UpdateRange(AuthUserItems));
        }

        public void UpdateRange(IEnumerable<Entity.AuthUserItem> entities)
        {
            this._authUserItemRepository.UpdateRange(entities);
        }
    }
}
