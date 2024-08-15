namespace TCCLions.Domain.Data.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<Guid> Add(TEntity entity);
    Task<bool> Update(TEntity entity);
    Task<bool> Delete(TEntity entity);
    Task<TEntity> GetById(Guid id);
     
}