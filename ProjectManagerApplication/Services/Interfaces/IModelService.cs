using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApplication.Services.Interfaces
{
    public interface IModelService<T>
    {
        public IEnumerable<T> GetAll();
        public Task<IEnumerable<T>> GetAllAsync();
        public T GetById(int id);
        public Task<T> GetByIdAsync(int id);
        public void Add(T model);
        public Task AddAsync(T model);
        public void Update(T model);
        public Task UpdateAsync(T model);
        public void Delete(T model);
        public Task DeleteAsync(T model);
    }
}
