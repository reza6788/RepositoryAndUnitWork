using Microsoft.EntityFrameworkCore;
using RepositoryAndUnitWork.Models;

namespace RepositoryAndUnitWork.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {
             
        }
    }
}
