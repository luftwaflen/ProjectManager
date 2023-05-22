using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;

namespace ProjectManagerInfrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PMDbContext _db;

        public ProjectRepository(PMDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ProjectModel> GetAll()
        {
            var projects = _db.Projects
                .Include(p => p.Users)
                .Include(p => p.Tasks)
                .ToList();
            return projects;
        }

        public async Task<IEnumerable<ProjectModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ProjectModel GetById(int id)
        {
            var project = _db.Projects.First(p => p.Id == id);
            return project;
        }

        public async Task<ProjectModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(ProjectModel model)
        {
            try
            {
                _db.Projects.Add(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task AddAsync(ProjectModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectModel model)
        {
            try
            {
                _db.Projects.Update(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(ProjectModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProjectModel model)
        {
            try
            {
                _db.Projects.Remove(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAsync(ProjectModel model)
        {
            throw new NotImplementedException();
        }
    }
}