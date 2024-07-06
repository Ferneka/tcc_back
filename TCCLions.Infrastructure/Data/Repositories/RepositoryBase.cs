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
            try
            {
                await _context.SaveChangesAsync();
                return (Guid)getId.GetValue(entity); 
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _entity.FindAsync(id);
            _entity.Remove(result);
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                var result = await _entity.ToListAsync();
                if(result.Any()) return result;
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public async Task<TEntity> GetById(Guid id)
        {
            try
            {
                var result = await _entity.FindAsync(id);
                if(result == null) return null;
                return result;
            }
            catch (System.Exception)
            {
                
                return null;
            }
          
        }

        public async Task<bool> Update(Guid id, TEntity entity)
        {
            var result = await _entity.FindAsync(id);
            if(result == null) return false; 
            var entry = _context.Entry(result);
            foreach(var property in entry.Properties){
                if(property.Metadata.Name != "Id"){
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
            }
            try
            {     
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}