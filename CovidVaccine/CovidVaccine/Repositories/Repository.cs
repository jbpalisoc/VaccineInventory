using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Repositories
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        protected TDbContext dbContext;
        public Repository(TDbContext context)
        {
            dbContext = context;
        }
        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);
            int isSuccess = await this.dbContext.SaveChangesAsync();
            //_ = await this.dbContext.SaveChangesAsync();
            return isSuccess > 0 ? entity : null;
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }


        public async Task<T> SelectById<T>(int id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }
    }
}
