using System;
using System.Collections.Generic;
using DataRange.DAL.DbContex;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataRange.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public async Task<T> Get(int id)
        {
            return await entities.FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var item = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return item.Entity;
            
        }


        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
