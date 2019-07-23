using BigStarter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigStarter.Domain.Contracts.Services
{
    public interface IProjectService
    {
        Task CreateProject(Project project);

        Task<IList<Project>> GetCompletedProjectByUser(int userId);

        IList<Project> GetAll();

        Task<Project> GetById(int id);
    }
}
