using CovidVaccine.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Repository
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        protected DbContext dbContext;
        public Repository(TDbContext context)
        {
            dbContext = context;
        }
        public void CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);
            //_ = await this.dbContext.SaveChangesAsync();
        }

        public void DeleteAsync<T>(T entity) where T : class
        {
             this.dbContext.Set<T>().Remove(entity);

            //_ = await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById<T>(int id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public void UpdateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);

            //_ = await this.dbContext.SaveChangesAsync();
        }
    }
}
