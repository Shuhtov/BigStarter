using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigStarter.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BigStarter.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        private readonly DatabaseContext _dbContext;

        public BaseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<IList<TEntity>> Get(Func<TEntity, bool> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).AsQueryable().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> Create(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                return _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
