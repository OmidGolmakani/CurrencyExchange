using CurrencyExchange.Data;
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
    public class Image : IImage
    {
        private readonly Repository<Entity.Image, long> ImageRepository;

        public Image(Repository<Entity.Image, long> repository)
        {
            this.ImageRepository = repository;
        }

        public Task<EntityEntry<Entity.Image>> Add(Entity.Image entity)
        {
            return ImageRepository.Add(entity);
        }

        public Task AddRange(IEnumerable<Entity.Image> entities)
        {
            return ImageRepository.AddRange(entities);
        }

        public Task<IEnumerable<Entity.Image>> Find(Func<Entity.Image, bool> expression)
        {
            return ImageRepository.Find(expression);
        }

        public Task<IEnumerable<Entity.Image>> GetAll()
        {
            return ImageRepository.GetAll();
        }

        public Task<Entity.Image> GetById(long Id)
        {
            return ImageRepository.GetById(Id);
        }

        public Task<IEnumerable<Entity.Image>> GetImageByUserId(long UserId)
        {
            var Result = ImageRepository.GetAll().Result.Where(x => x.UserId == UserId).AsEnumerable();
            return Task.FromResult(Result);
        }

        public void Remove(long Id)
        {
            ImageRepository.Remove(Id);
        }

        public void RemoveRange(IEnumerable<Entity.Image> entities)
        {
            ImageRepository.RemoveRange(entities);
        }

        public int SaveChanges()
        {
            return ImageRepository.SaveChanges();
        }

        public void Update(Entity.Image entity)
        {
            ImageRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Entity.Image> entities)
        {
            ImageRepository.UpdateRange(entities);
        }
    }
}
