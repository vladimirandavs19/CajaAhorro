using CajaAhorro.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext dataContext;

        public GenericRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable<T> GetAll()
        {
            return this.dataContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.dataContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(T entity)
        {
            await this.dataContext.Set<T>().AddAsync(entity);
            await SaveAllChangesAsync();
        }

        public async Task SaveAllChangesAsync()
        {
            await this.dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.dataContext.Set<T>().Remove(entity);
            await SaveAllChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.dataContext.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            this.dataContext.Set<T>().Update(entity);
            await SaveAllChangesAsync();
        }
    }
}
