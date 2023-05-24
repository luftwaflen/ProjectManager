using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;

namespace ProjectManagerApplication.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IWorkTimeRepository _workTimeRepository;

        public TaskService(ITaskRepository taskRepository, IWorkTimeRepository workTimeRepository)
        {
            _taskRepository = taskRepository;
            _workTimeRepository = workTimeRepository;
        }

        public IEnumerable<TaskModel> GetAll()
        {
            var tasks = _taskRepository.GetAll();
            return tasks;
        }

        public IEnumerable<TaskModel> GetUserTasks(int userId)
        {
            var userTasks = _taskRepository
                .GetAll()
                .Where(p => p.Appender.Id == userId || p.Executor.Id == userId)
                .ToList();
            return userTasks;
        }

        public IEnumerable<TaskModel> GetProjectTasks(int projectId)
        {
            var projectTasks = _taskRepository
                .GetAll()
                .Where(p => p.Project.Id == projectId)
                .ToList();
            return projectTasks;
        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public TaskModel GetById(int id)
        {
            var task = _taskRepository.GetById(id);
            return task;
        }

        public async Task<TaskModel> GetByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public void Add(TaskModel model)
        {
            try
            {
                _taskRepository.Add(model);
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
                await _taskRepository.AddAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SetExecutor(UserModel user, int taskId)
        {
            var task = _taskRepository.GetById(taskId);
            task.Executor = user;
            var time = new TimeSpan(0, 0, 0, 0);
            var workTime = new WorkTimeModel
            {
                Task = task,
                User = user,
                Time = time,

            };
            _workTimeRepository.Add(workTime);
            task.WorkTimes.Add(workTime);
            _taskRepository.Update(task);
        }
        
        public void Update(TaskModel model)
        {
            try
            {
                _taskRepository.Update(model);
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
                await _taskRepository.UpdateAsync(model);
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
                _taskRepository.Delete(model);
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
                var task = _taskRepository.GetById(id);
                _taskRepository.Delete(task);
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
                await _taskRepository.DeleteAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}