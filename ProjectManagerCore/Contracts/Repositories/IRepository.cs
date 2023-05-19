namespace ProjectManagerCore.Contracts.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public Task<IEnumerable<T>> GetAllAsync();
        public T GetById(int id);
        public Task<T> GetAllAsync(int id);
        public void Add(T model);
        public Task AddAsync(T model);
        public void Update(T model);
        public Task UpdateAsync(T model);
        public void Delete(T model);
        public Task DeleteAsync(T model);
    }
}
