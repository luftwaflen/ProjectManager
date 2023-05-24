using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Interfaces
{
    public interface IWorkTimeService : IModelService<WorkTimeModel>
    {
        public IEnumerable<WorkTimeModel> GetUserWorkTimes(int userId);
        public WorkTimeModel GetTaskWorkTime(UserModel user, TaskModel task);
        public void DeleteById(int id);
    }
}