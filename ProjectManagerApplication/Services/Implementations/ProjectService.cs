using Microsoft.AspNetCore.Identity;
using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;
using ProjectManagerInfrastructure.Managers;

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
            var user = _userManager.Users.First(u => u.Id == userId);
            var userProjects = GetAll().Where(p => p.Users.Contains(user)).ToList();
            //var userProjects = _userManager.Users.First(u => u.Id == userId).Projects;
            return userProjects;
        }

        public IEnumerable<TaskModel> GetProjectTasks(int projectId)
        {
            var project = _projectRepository.GetById(projectId);
            var tasks = project.Tasks;

            return tasks;
        }

        public IEnumerable<UserModel> GetProjectUsers(int projectId)
        {
            var project = _projectRepository.GetById(projectId);
            var users = project.Users;

            return users;
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

        public void AddUserToProject(int projectId, UserModel user, int roleId)
        {
            var project = _projectRepository.GetById(projectId);
            project.Users.Add(user);
            _userManager.AddProjectRole(user, project, roleId);
            _projectRepository.Update(project);
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