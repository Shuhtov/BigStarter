using BigStarter.Domain.Contracts.Repositories;
using BigStarter.Domain.Contracts.Services;
using BigStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStarter.Domain.Services
{
    public class ProjectService: IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IBaseRepository<Project> _projectRepository2;

        public ProjectService(IProjectRepository projectRepository,
            IBaseRepository<Project> projectRepository2)
        {
            _projectRepository = projectRepository;
            _projectRepository2 = projectRepository2;
        }

        public async Task CreateProject(Project project)
        {
            await _projectRepository.Create(project);
        }

        public async Task<IList<Project>> GetCompletedProjectByUser(int userId)
        {
            return await _projectRepository2.Get(x => x.IsCompleted && x.OwnerId == userId);
        }

        public IList<Project> GetAll()
        {
            return _projectRepository2.GetAll().ToList();
        }

        public async Task<Project> GetById(int id)
        {
            return await _projectRepository2.GetById(id);
        }
    }
}
