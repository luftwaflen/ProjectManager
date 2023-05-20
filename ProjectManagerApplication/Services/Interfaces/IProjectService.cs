using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Interfaces
{
    public interface IProjectService : IModelService<ProjectModel>
    {
        public IEnumerable<ProjectModel> GetUserProjects(int userId);
        public IEnumerable<TaskModel> GetProjectTasks(int projectId);
        public void UpdateById(int id);
        public void DeleteById(int id);
    }
}