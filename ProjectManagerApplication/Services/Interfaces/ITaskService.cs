using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Interfaces
{
    public interface ITaskService : IModelService<TaskModel>
    {
        public IEnumerable<TaskModel> GetUserTasks(int userId);
        public IEnumerable<TaskModel> GetProjectTasks(int projectId);
        public void DeleteById(int id);
    }
}