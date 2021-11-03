using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryAndUnitWork.Core.IRepositories;
using RepositoryAndUnitWork.Data;
using RepositoryAndUnitWork.Models;

namespace RepositoryAndUnitWork.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApiDbContext apiDbContext, ILogger logger) : base(apiDbContext, logger)
        {
        }

        public override async Task<List<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(p => p.Id == entity.Id).FirstOrDefaultAsync();
                if (existingUser == null)
                    return await Add(entity);

                existingUser.Email = entity.Email;
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var existingUser = await dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (existingUser == null)
                    return false;
                dbSet.Remove(existingUser);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(UserRepository));
                return false;
            }
        }
    }
}
