using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            entities.Update(entity);
            return context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            T entity = entities.SingleOrDefault(entity => entity.Id == id);
            entities.Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}