using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;

namespace ProjectManagerInfrastructure.Repositories
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly PMDbContext _db;

        public WorkTimeRepository(PMDbContext db)
        {
            _db = db;
        }

        public IEnumerable<WorkTimeModel> GetAll()
        {
            var workTimes = _db.WorkTimes.ToList();
            return workTimes;
        }

        public async Task<IEnumerable<WorkTimeModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public WorkTimeModel GetById(int id)
        {
            var workTime = _db.WorkTimes.First(wt => wt.Id == id);
            return workTime;
        }

        public async Task<WorkTimeModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(WorkTimeModel model)
        {
            try
            {
                _db.WorkTimes.Add(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task AddAsync(WorkTimeModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkTimeModel model)
        {
            try
            {
                _db.WorkTimes.Update(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(WorkTimeModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(WorkTimeModel model)
        {
            try
            {
                _db.WorkTimes.Remove(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAsync(WorkTimeModel model)
        {
            throw new NotImplementedException();
        }
    }
}