using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;

namespace ProjectManagerInfrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly PMDbContext _db;

        public TaskRepository(PMDbContext db)
        {
            _db = db;
        }

        public IEnumerable<TaskModel> GetAll()
        {
            var tasks = _db.Tasks.ToList();
            return tasks;
        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TaskModel GetById(int id)
        {
            var task = _db.Tasks.First(t => t.Id == id);
            return task;
        }

        public async Task<TaskModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(TaskModel model)
        {
            try
            {
                _db.Tasks.Add(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task AddAsync(TaskModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskModel model)
        {
            try
            {
                _db.Tasks.Update(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(TaskModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskModel model)
        {
            try
            {
                _db.Tasks.Remove(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAsync(TaskModel model)
        {
            throw new NotImplementedException();
        }
    }
}