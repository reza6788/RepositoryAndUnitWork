using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryAndUnitWork.Core.IRepositories;
using RepositoryAndUnitWork.Data;

namespace RepositoryAndUnitWork.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext _apiDbContext;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(
            ApiDbContext apiDbContext,
            ILogger logger)
        {
            _apiDbContext = apiDbContext;
            _logger = logger;
            dbSet = apiDbContext.Set<T>();
        }

        public virtual async Task<List<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var findAsync = await dbSet.FindAsync(id);
            dbSet.Remove(findAsync);
            return true;
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
