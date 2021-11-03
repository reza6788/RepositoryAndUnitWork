using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryAndUnitWork.Core.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        //Task<bool> Edit(T entity,Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);

    }
}
