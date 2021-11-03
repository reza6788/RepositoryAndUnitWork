using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RepositoryAndUnitWork.Core.IConfiguration;
using RepositoryAndUnitWork.Core.IRepositories;
using RepositoryAndUnitWork.Core.Repositories;

namespace RepositoryAndUnitWork.Data
{
    public class UnitOfWork : IUnitOfWork ,IDisposable
    {
        private readonly ApiDbContext _apiDbContext;
        private readonly ILogger _logger;
        public IUserRepository Users { get; set; }

        public UnitOfWork(ApiDbContext apiDbContext,ILoggerFactory loggerFactory)
        {
            _apiDbContext = apiDbContext;
            _logger = loggerFactory.CreateLogger("Logs");
            Users=new UserRepository(apiDbContext,_logger);
        }

        public async Task CompleteAsync()
        {
            await _apiDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _apiDbContext.Dispose();
        }
    }
}
