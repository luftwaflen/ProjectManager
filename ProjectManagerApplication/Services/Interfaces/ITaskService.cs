using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Interfaces
{
    public interface ITaskService : IModelService<TaskModel>
    {
        //Возможно стоит перенести в user'а
        public IEnumerable<TaskModel> GetUserTasks(int userId);
        public void DeleteById(int id);
    }
}