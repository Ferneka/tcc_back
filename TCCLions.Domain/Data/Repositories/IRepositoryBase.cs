using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<Guid> Add(TEntity entity);
        Task<bool> Update(Guid id, TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> GetById(Guid id);
         
    }
}