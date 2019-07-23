using BigStarter.Domain.Contracts.Repositories;
using BigStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStarter.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Project>> GetCompleted()
        {
            return await Get(x => x.IsCompleted);
        }
    }
}
