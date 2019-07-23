using BigStarter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigStarter.Domain.Contracts.Repositories
{
    public interface IProjectRepository: IBaseRepository<Project>
    {
        Task<IList<Project>> GetCompleted();
    }
}
