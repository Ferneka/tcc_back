using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDataContext _context;
        protected readonly DbSet<TEntity> _entity;
        public RepositoryBase(ApplicationDataContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }
        public async Task<Guid> Add(TEntity entity)
        {
            _entity.Add(entity);
            var getId = entity.GetType().GetProperty("Id");
            await _context.SaveChangesAsync();
            return (Guid)getId.GetValue(entity); 
            
            
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _entity.Remove(entity);

            return await _context.SaveChangesAsync() > 1;
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<bool> Update(TEntity entity)
        {
            _entity.Update(entity);

            return await _context.SaveChangesAsync() > 1;
        }
    }
}