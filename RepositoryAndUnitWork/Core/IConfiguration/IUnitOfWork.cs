using System.Threading.Tasks;
using RepositoryAndUnitWork.Core.IRepositories;

namespace RepositoryAndUnitWork.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; set; }
        Task CompleteAsync();
    }
}
