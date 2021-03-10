using System;
using System.Collections.Generic;
using System.Linq;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess
{

    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly RecipeStorageContext context;
        private DbSet<T> entities;
        public Repository(RecipeStorageContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(entity => entity.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(entity => entity.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}