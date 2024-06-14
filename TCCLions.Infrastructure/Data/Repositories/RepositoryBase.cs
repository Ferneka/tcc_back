using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDataContext _context;
        public RepositoryBase(ApplicationDataContext context){
            _context = context;
        }
        public async Task<Guid> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
           await  _context.SaveChangesAsync();
            var getId = entity.GetType().GetProperty("Id");
            return (Guid)getId.GetValue(entity);
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var result = _context.Set<TEntity>();
            if(result.Count() > 0) return await result.ToListAsync();
            return null;
        }
        public async Task<TEntity> GetById(Guid id)
        {
            var getId =  _context.Set<TEntity>().Where(x => x.Id == id);
            if(getId.Any()) return getId.FirstOrDefault();
            return null;
        }

        public async Task<bool> Update(Guid id, TEntity entity)
        {
            var getEntity = await _context.Set<TEntity>().FindAsync(id);
            if(getEntity == null) return false;
            _context.Entry(getEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}