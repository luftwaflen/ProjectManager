using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Implementations
{
    public class WorkTImeService : IWorkTimeService
    {
        private readonly IWorkTimeRepository _repository;

        public WorkTImeService(IWorkTimeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<WorkTimeModel> GetAll()
        {
            var workTimes = _repository.GetAll();
            return workTimes;
        }

        public IEnumerable<WorkTimeModel> GetUserWorkTimes(int userId)
        {
            var userWorkTimes = _repository
                .GetAll()
                .Where(wt => wt.User.Id == userId)
                .ToList();
            return userWorkTimes;
        }

        public async Task<IEnumerable<WorkTimeModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public WorkTimeModel GetById(int id)
        {
            var workTime = _repository.GetById(id);
            return workTime;
        }

        public async Task<WorkTimeModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Add(WorkTimeModel model)
        {
            try
            {
                _repository.Add(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task AddAsync(WorkTimeModel model)
        {
            try
            {
                 await _repository.AddAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(WorkTimeModel model)
        {
            try
            {
                _repository.Update(model);
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
                var workTime = _repository.GetById(id);
                _repository.Add(workTime);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(WorkTimeModel model)
        {
            try
            {
                await _repository.UpdateAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(WorkTimeModel model)
        {
            try
            {
                _repository.Delete(model);
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
                var workTime = _repository.GetById(id);
                _repository.Add(workTime);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAsync(WorkTimeModel model)
        {
            try
            {
                await _repository.DeleteAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}