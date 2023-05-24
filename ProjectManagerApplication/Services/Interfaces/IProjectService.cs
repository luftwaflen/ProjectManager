using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Interfaces
{
    public interface IProjectService : IModelService<ProjectModel>
    {
        public IEnumerable<ProjectModel> GetUserProjects(int userId);
        public IEnumerable<TaskModel> GetProjectTasks(int projectId);
        public IEnumerable<UserModel> GetProjectUsers(int projectId);
        public void AddUserToProject(int projectId, UserModel user, int roleId);
        public void DeleteById(int id);
    }
}