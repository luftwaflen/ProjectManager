using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TaskModel> GetAll()
        {
            var tasks = _repository.GetAll();
            return tasks;
        }

        public IEnumerable<TaskModel> GetUserTasks(int userId)
        {
            var userTasks = _repository
                .GetAll()
                .Where(p => p.Appender.Id == userId || p.Executor.Id == userId)
                .ToList();
            return userTasks;
        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public TaskModel GetById(int id)
        {
            var task = _repository.GetById(id);
            return task;
        }

        public async Task<TaskModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Add(TaskModel model)
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

        public async Task AddAsync(TaskModel model)
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

        public void Update(TaskModel model)
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
                var task = _repository.GetById(id);
                _repository.Update(task);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(TaskModel model)
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

        public void Delete(TaskModel model)
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
                var task = _repository.GetById(id);
                _repository.Delete(task);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAsync(TaskModel model)
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