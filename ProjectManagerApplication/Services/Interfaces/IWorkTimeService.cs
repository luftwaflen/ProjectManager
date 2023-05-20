using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Interfaces
{
    public interface IWorkTimeService : IModelService<WorkTimeModel>
    {
        public IEnumerable<WorkTimeModel> GetUserWorkTimes(int userId);
        public void UpdateById(int id);
        public void DeleteById(int id);
    }
}