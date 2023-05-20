using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Managers;
using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly CustomUserManager _userManager;

        public ProjectService(IProjectRepository projectRepository, CustomUserManager userManager)
        {
            _projectRepository = projectRepository;
            _userManager = userManager;
        }

        public IEnumerable<ProjectModel> GetAll()
        {
            var projects = _projectRepository.GetAll();
            return projects;
        }

        public async Task<IEnumerable<ProjectModel>> GetAllAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public ProjectModel GetById(int id)
        {
            var project = _projectRepository.GetById(id);
            return project;
        }

        public async Task<ProjectModel> GetByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public IEnumerable<ProjectModel> GetUserProjects(int userId)
        {
            var userProjects = _userManager.Users.First(u => u.Id == userId).Projects;
            return userProjects;
        }

        public IEnumerable<TaskModel> GetProjectTasks(int projectId)
        {
            throw new NotImplementedException();
        }


        public void Add(ProjectModel model)
        {
            try
            {
                _projectRepository.Add(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task AddAsync(ProjectModel model)
        {
            try
            {
                await _projectRepository.AddAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(ProjectModel model)
        {
            try
            {
                _projectRepository.Update(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateById(int id)
        {
            try
            {
                var project = _projectRepository.GetById(id);
                _projectRepository.Update(project);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(ProjectModel model)
        {
            try
            {
                await _projectRepository.UpdateAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(ProjectModel model)
        {
            try
            {
                _projectRepository.Delete(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                var project = _projectRepository.GetById(id);
                _projectRepository.Delete(project);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAsync(ProjectModel model)
        {
            try
            {
                await _projectRepository.DeleteAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}