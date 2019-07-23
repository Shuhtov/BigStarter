using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigStarter.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity>
            where TEntity : IBaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<IList<TEntity>> Get(Func<TEntity, bool> predicate);

        Task<int> Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}
